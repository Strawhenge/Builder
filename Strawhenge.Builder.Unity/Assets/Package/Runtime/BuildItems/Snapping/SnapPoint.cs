using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class SnapPoint
    {
        private readonly Transform transform;
        private readonly Transform root;

        public SnapPoint(Transform point)
        {
            transform = point;
            root = point.root;
        }

        public Vector3 Position => transform.position;

        public Quaternion Rotation => transform.rotation;

        public void SetPosition(Vector3 position)
        {
            var directionToRoot = transform.position - root.position;
            var targetPositionForRoot = position - directionToRoot;

            root.position = targetPositionForRoot;
        }

        public void SetRotation(Quaternion rotation)
        {
            var currentPosition = transform.position;

            var relativeRotation = Quaternion.Inverse(transform.rotation) * root.rotation;
            root.rotation = rotation * relativeRotation;

            SetPosition(currentPosition);
        }
    }
}