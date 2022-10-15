using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class SnapPoint
    {
        readonly Transform _transform;
        readonly Transform _root;

        public SnapPoint(Transform point)
        {
            _transform = point;
            _root = point.root;
        }

        public Vector3 Position => _transform.position;

        public Quaternion Rotation => _transform.rotation;

        public void SetPosition(Vector3 position)
        {
            var directionToRoot = _transform.position - _root.position;
            var targetPositionForRoot = position - directionToRoot;

            _root.position = targetPositionForRoot;
        }

        public void SetRotation(Quaternion rotation)
        {
            var currentPosition = _transform.position;

            var relativeRotation = Quaternion.Inverse(_transform.rotation) * _root.rotation;
            _root.rotation = rotation * relativeRotation;

            SetPosition(currentPosition);
        }
    }
}