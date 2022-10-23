using System;
using System.Linq;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemController : IBuildItemController
    {
        readonly ControlsToggle _controls;

        IBuildItem _currentBuildItem;
        IArrangeBuildItem _arrangeCurrentBuildItem;
        Func<bool> _canPlaceFinalItem;
        Action _onPlacedFinalItem;
        Action _onCancelled;

        public BuildItemController(
            IBuildItemControls buildItemControls,
            IVerticalSnapControls verticalSnapControls,
            IHorizontalSnapControls horizontalSnapControls)
        {
            _controls = new ControlsToggle(
                buildItemControls,
                verticalSnapControls,
                horizontalSnapControls);

            _controls.Place += SpawnFinalItem;
            _controls.Snap += OnSnap;
            _controls.ReleaseSnap += OnReleaseSnap;

            ResetCallbacks();
        }

        public UpdatablePosition LastPlacedPosition { get; } = new UpdatablePosition();

        public void PreviewOn(IBuildItem buildItem, Func<bool> canPlaceFinalItem = null,
            Action onPlacedFinalItem = null, Action onCancelled = null)
        {
            _currentBuildItem?.Cancel();
            _currentBuildItem = buildItem;

            _canPlaceFinalItem = canPlaceFinalItem ?? (() => true);
            _onPlacedFinalItem = onPlacedFinalItem ?? (() => { });
            _onCancelled = onCancelled ?? (() => { });

            _arrangeCurrentBuildItem = buildItem.Arrange();
            _controls.BuildControlsOn(_arrangeCurrentBuildItem);
        }

        public void PreviewOff()
        {
            _currentBuildItem?.Cancel();
            _currentBuildItem = null;

            _controls.ControlsOff();

            var callback = _onCancelled;
            ResetCallbacks();
            callback();
        }

        void SpawnFinalItem()
        {
            if (_currentBuildItem == null || _arrangeCurrentBuildItem == null || !_canPlaceFinalItem())
                return;

            _currentBuildItem.PlaceFinal();
            _currentBuildItem = null;

            _controls.ControlsOff();

            LastPlacedPosition.Update(_arrangeCurrentBuildItem.Position, _arrangeCurrentBuildItem.Rotation);

            var callback = _onPlacedFinalItem;
            ResetCallbacks();
            callback();
        }

        void OnSnap()
        {
            var verticalSnap = _arrangeCurrentBuildItem.GetAvailableVerticalSnaps().FirstOrDefault();

            if (verticalSnap != null)
            {
                verticalSnap.Snap();
                _controls.VerticalSnapControlsOn(verticalSnap);
                return;
            }

            var horizontalSnap = _arrangeCurrentBuildItem.GetAvailableHorizontalSnaps().FirstOrDefault();

            if (horizontalSnap == null)
                return;

            horizontalSnap.Snap();
            _controls.HorizontalSnapControlsOn(horizontalSnap);
        }

        void OnReleaseSnap()
        {
            _controls.BuildControlsOn(_arrangeCurrentBuildItem);
        }

        void ResetCallbacks()
        {
            _canPlaceFinalItem = () => true;
            _onPlacedFinalItem = () => { };
            _onCancelled = () => { };
        }
    }
}