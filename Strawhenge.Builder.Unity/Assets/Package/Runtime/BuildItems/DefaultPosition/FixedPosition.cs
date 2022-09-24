using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class FixedPosition : IDefaultPositionAccessor
    {
        readonly Vector3 _position;
        readonly Quaternion _rotation;

        public FixedPosition(Vector3 position, Quaternion rotation)
        {
            _position = position;
            _rotation = rotation;
        }

        public Vector3 GetPosition()
        {
            return _position;
        }

        public Quaternion GetRotation()
        {
            return _rotation;
        }
    }
}