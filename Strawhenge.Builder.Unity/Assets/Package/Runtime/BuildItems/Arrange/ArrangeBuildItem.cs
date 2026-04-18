using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Common.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Arrange
{
    class ArrangeBuildItem : IArrangeBuildItem
    {
        readonly Transform _transform;
        readonly IReadOnlyList<Collider> _colliders;
        readonly Func<IEnumerable<VerticalSnap>> _getAvailableVerticalSnaps;
        readonly Func<IEnumerable<HorizontalSnap>> _getAvailableHorizontalSnaps;

        ArrangeBuildItemScript _script;
        bool _isEnabled;

        float _turnAngle;
        float _tiltAngle;

        public ArrangeBuildItem(
            Transform transform,
            IReadOnlyList<Collider> colliders,
            Func<IEnumerable<VerticalSnap>> getAvailableVerticalSnaps,
            Func<IEnumerable<HorizontalSnap>> getAvailableHorizontalSnaps)
        {
            _transform = transform;
            _colliders = colliders;
            _getAvailableVerticalSnaps = getAvailableVerticalSnaps;
            _getAvailableHorizontalSnaps = getAvailableHorizontalSnaps;
        }

        public event Action ClippingChanged;

        public Vector3 Position => _transform.position;

        public Quaternion Rotation => _transform.rotation;

        public bool ClippingDisabled { get; private set; }

        public IEnumerable<VerticalSnap> GetAvailableVerticalSnaps() =>
            _getAvailableVerticalSnaps().ToArray();

        public IEnumerable<HorizontalSnap> GetAvailableHorizontalSnaps() =>
            _getAvailableHorizontalSnaps().ToArray();

        public void Enable()
        {
            if (_isEnabled)
                Disable();

            _isEnabled = true;
            _script = _transform.GetOrAddComponent<ArrangeBuildItemScript>();

            if (ClippingDisabled)
                ToggleColliders(false);
        }

        public void Disable()
        {
            ObjectHelper.Destroy(_script);

            _isEnabled = false;

            ToggleColliders(true);
        }

        public Transform GetTransform() => _transform;

        public void Move(Vector3 velocity)
        {
            if (_isEnabled)
                _script.Move(velocity);
        }

        public void Turn(float amount)
        {
            if (_isEnabled)
                _script.Turn(amount);
        }

        public void ClippingOn()
        {
            if (!ClippingDisabled)
                return;

            ClippingDisabled = false;

            if (_isEnabled)
                ToggleColliders(true);

            ClippingChanged?.Invoke();
        }

        public void ClippingOff()
        {
            if (ClippingDisabled)
                return;

            ClippingDisabled = true;

            if (_isEnabled)
                ToggleColliders(false);

            ClippingChanged?.Invoke();
        }

        public void PlaceAt(Vector3 position, Quaternion rotation)
        {
            _transform.position = position;
            _transform.rotation = rotation;
        }

        void ToggleColliders(bool enabled)
        {
            foreach (var collider in _colliders)
                collider.enabled = enabled;
        }
    }
}