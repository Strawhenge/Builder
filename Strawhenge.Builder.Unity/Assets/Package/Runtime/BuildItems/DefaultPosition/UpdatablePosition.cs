using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class UpdatablePosition : IDefaultPositionAccessor
    {
        Vector3 _position;
        Quaternion _rotation;

        public void Update(Vector3 position, Quaternion rotation)
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