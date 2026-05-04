using Strawhenge.Builder.Unity.Camera;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Sample
{
    public class PanningCameraControllerScript : CameraControllerScript, ICameraController
    {
        [SerializeField] Camera _camera;
        [SerializeField] float _distance = 5;

        Transform _cameraTransform;
        Transform _anchor;

        public override ICameraController CameraController => this;

        public void FocusOnBuildItem(Transform anchor)
        {
            _anchor = anchor;
        }

        public void FocusOnSnapPoint(Transform anchor)
        {
            _anchor = anchor;
        }

        public void Unfocus()
        {
            _anchor = null;
        }

        void Awake()
        {
            ComponentRefHelper.EnsureCamera(ref _camera, nameof(_camera), this);
            _cameraTransform = _camera.transform;
        }

        void Update()
        {
            if (ReferenceEquals(_anchor, null)) return;

            var direction = _cameraTransform.forward.normalized * -1;
            _cameraTransform.position = _anchor.position + direction * _distance;
        }
    }
}