using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class InFrontOfCameraDefaultPositionScript : DefaultPositionAccessorScript
    {
        [SerializeField] Camera _camera;
        [SerializeField] float _distance;
        [SerializeField] LayerMask _collisionLayerMask;

        InFrontOfCameraDefaultPosition _frontOfCameraDefaultPosition;

        public override IDefaultPositionAccessor DefaultPositionAccessor => _frontOfCameraDefaultPosition ??= Create();

        InFrontOfCameraDefaultPosition Create()
        {
            ComponentRefHelper
                .EnsureCamera(ref _camera, nameof(_camera), this);

            return new InFrontOfCameraDefaultPosition(_camera, _distance, _collisionLayerMask);
        }
    }
}