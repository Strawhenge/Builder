using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    class InFrontOfCameraDefaultPosition : IDefaultPositionAccessor
    {
        readonly Camera _camera;
        readonly float _distance;
        readonly LayerMask _collisionLayerMask;

        public InFrontOfCameraDefaultPosition(Camera camera, float distance, LayerMask collisionLayerMask)
        {
            _camera = camera;
            _distance = distance;
            _collisionLayerMask = collisionLayerMask;
        }

        public Vector3 GetPosition()
        {
            var cameraTransform = _camera.transform;

            if (Physics.Raycast(
                    cameraTransform.position,
                    cameraTransform.forward,
                    out var hit,
                    _distance,
                    _collisionLayerMask))
            {
                return hit.point - cameraTransform.forward;
            }

            return cameraTransform.position + cameraTransform.forward * _distance;
        }

        public Quaternion GetRotation()
        {
            return Quaternion.Euler(
                _camera.transform.rotation.eulerAngles.x,
                0,
                _camera.transform.rotation.eulerAngles.z);
        }
    }
}