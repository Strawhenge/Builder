﻿using System;
using System.Linq;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public partial class BuildItemController : IBuildItemController
    {
        readonly ICameraController _camera;
        readonly ControlsToggle _controls;
        readonly Callbacks _callbacks;

        IBuildItem _currentBuildItem;
        IExistingBuildItem _currentExistingBuildItem;
        IArrangeBuildItem _arrangeCurrentBuildItem;
        bool _clippingDisabled;
        bool _canScrap;

        public BuildItemController(
            ICameraController camera,
            IBuildItemControls buildItemControls,
            IVerticalSnapControls verticalSnapControls,
            IHorizontalSnapControls horizontalSnapControls)
        {
            _camera = camera;
            _controls = new ControlsToggle(
                buildItemControls,
                verticalSnapControls,
                horizontalSnapControls);

            _controls.Place += SpawnFinalItem;
            _controls.Snap += OnSnap;
            _controls.ReleaseSnap += OnReleaseSnap;
            _controls.Cancel += Off;
            _controls.Scrap += OnScrap;

            _callbacks = new Callbacks();
        }

        public UpdatablePosition LastPlacedPosition { get; } = new UpdatablePosition();

        public void On(
            IBuildItem buildItem,
            Func<bool> canPlaceFinalItem = null,
            Action onPlacedFinalItem = null,
            Action onCancelled = null)
        {
            Off();

            _callbacks.Set(
                canPlaceItem: canPlaceFinalItem,
                onPlacedItem: onPlacedFinalItem,
                onCancelled: onCancelled);

            Begin(buildItem, false);
        }

        public void On(
            IExistingBuildItem buildItem,
            Action onPlacedItem = null,
            Action onScrapped = null,
            Action onCancelled = null)
        {
            Off();

            _callbacks.Set(
                onPlacedItem: onPlacedItem,
                onCancelled: onCancelled,
                onScrapped: onScrapped);

            _currentExistingBuildItem = buildItem;

            Begin(buildItem, true);
        }

        public void Off()
        {
            _camera.Unfocus();
            _controls.ControlsOff();

            _currentBuildItem?.Cancel();
            ResetCurrentBuildItem();

            _callbacks.OnCancelled();
        }

        void Begin(IBuildItem buildItem, bool canScrap)
        {
            _currentBuildItem = buildItem;
            _arrangeCurrentBuildItem = buildItem.Arrange();
            _arrangeCurrentBuildItem.ClippingChanged += OnClippingChanged;

            _camera.FocusOnBuildItem(_arrangeCurrentBuildItem.GetTransform());

            _canScrap = canScrap;
            _controls.BuildControlsOn(_arrangeCurrentBuildItem, canScrap);

            if (_clippingDisabled)
                _arrangeCurrentBuildItem.ClippingOff();
        }

        void SpawnFinalItem()
        {
            if (_currentBuildItem == null || _arrangeCurrentBuildItem == null || !_callbacks.CanPlaceItem())
                return;

            _camera.Unfocus();
            _controls.ControlsOff();
            _currentBuildItem.PlaceFinal();

            LastPlacedPosition.Update(_arrangeCurrentBuildItem.Position, _arrangeCurrentBuildItem.Rotation);

            ResetCurrentBuildItem();

            _callbacks.OnPlacedItem();
        }

        void OnSnap()
        {
            var verticalSnap = _arrangeCurrentBuildItem.GetAvailableVerticalSnaps().FirstOrDefault();

            if (verticalSnap != null)
            {
                verticalSnap.Snap();
                _camera.FocusOnSnapPoint(verticalSnap.GetSnappedToTransform());
                _controls.VerticalSnapControlsOn(verticalSnap);
                return;
            }

            var horizontalSnap = _arrangeCurrentBuildItem.GetAvailableHorizontalSnaps().FirstOrDefault();

            if (horizontalSnap != null)
            {
                horizontalSnap.Snap();
                _camera.FocusOnSnapPoint(horizontalSnap.GetSnappedToTransform());
                _controls.HorizontalSnapControlsOn(horizontalSnap);
            }
        }

        void OnReleaseSnap()
        {
            _controls.BuildControlsOn(_arrangeCurrentBuildItem, _canScrap);
            _camera.FocusOnBuildItem(_arrangeCurrentBuildItem.GetTransform());
        }

        void OnClippingChanged()
        {
            _clippingDisabled = _arrangeCurrentBuildItem?.ClippingDisabled ?? false;
        }

        void OnScrap()
        {
            if (_currentExistingBuildItem == null)
                return;

            _currentExistingBuildItem.Scrap();
            _callbacks.OnScrapped();
            ResetCurrentBuildItem();
        }

        void ResetCurrentBuildItem()
        {
            _currentBuildItem = null;
            _currentExistingBuildItem = null;

            if (_arrangeCurrentBuildItem != null)
            {
                _arrangeCurrentBuildItem.ClippingChanged -= OnClippingChanged;
                _arrangeCurrentBuildItem = null;
            }
        }
    }
}