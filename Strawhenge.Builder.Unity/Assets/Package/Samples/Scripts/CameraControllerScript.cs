using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class CameraControllerScript : MonoBehaviour, ICameraController
    {
        [SerializeField] float _distance;

        Transform _cameraTransform;
        Transform _anchor;

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
            _cameraTransform = FindObjectOfType<Camera>().transform;
        }

        void Update()
        {
            if (ReferenceEquals(_anchor, null)) return;

            var direction = _cameraTransform.forward.normalized * -1;
            _cameraTransform.position = _anchor.position + direction * _distance;
        }
    }
}