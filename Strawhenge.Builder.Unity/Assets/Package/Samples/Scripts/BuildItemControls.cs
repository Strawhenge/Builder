using Strawhenge.Builder.Unity.BuildItems;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BuildItemControls : MonoBehaviour, IBuildItemControls
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _turnSpeed;
        [SerializeField] float _cameraDistance;

        Transform _cameraTransform;
        IArrangeBuildItem _buildItem;
        bool _canScrap;

        public event Action Place;
        public event Action Snap;
        public event Action Cancel;
        public event Action Scrap;

        public void ControlOn(IArrangeBuildItem buildItem, bool canScrap)
        {
            _buildItem = buildItem;
            _canScrap = canScrap;
            enabled = true;
        }

        public void ControlOff()
        {
            enabled = false;
            _buildItem = null;
        }

        void Awake()
        {
            _cameraTransform = FindObjectOfType<Camera>().transform;
        }

        void OnEnable()
        {
            if (_buildItem == null)
                enabled = false;
        }

        void Update()
        {
            UpdateCamera();
            ManageBlueprintMovement();
            ManageClippingToggle();

            if (Input.GetKeyDown(KeyCode.Return))
                Place?.Invoke();

            if (Input.GetKeyDown(KeyCode.RightShift))
                Snap?.Invoke();

            if (Input.GetKeyDown(KeyCode.Escape))
                Cancel?.Invoke();

            if (_canScrap && Input.GetKeyDown(KeyCode.Backspace))
                Scrap?.Invoke();
        }

        void ManageBlueprintMovement()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _buildItem.Move(_moveSpeed * new Vector3(0, y, 0).normalized);
                _buildItem.Turn(_turnSpeed * x);
                return;
            }

            var direction = new Vector3(x, 0, y).normalized;
            _buildItem.Move(_moveSpeed * direction);
        }

        void ManageClippingToggle()
        {
            if (!Input.GetKeyDown(KeyCode.CapsLock))
                return;

            if (_buildItem.ClippingDisabled)
                _buildItem.ClippingOn();
            else
                _buildItem.ClippingOff();
        }

        void UpdateCamera()
        {
            var direction = _cameraTransform.forward.normalized * -1;

            _cameraTransform.position = _buildItem.Position + direction * _cameraDistance;
        }
    }
}