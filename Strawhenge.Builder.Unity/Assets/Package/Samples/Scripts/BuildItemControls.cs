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
        IBuildItemPreview _buildItem;

        public event Action Place;
        public event Action Snap;

        public void ControlOn(IBuildItemPreview buildItem)
        {
            _buildItem = buildItem;
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

            if (Input.GetKeyDown(KeyCode.Return))
                Place?.Invoke();

            if (Input.GetKeyDown(KeyCode.RightShift))
                Snap?.Invoke();
        }

        void ManageBlueprintMovement()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _buildItem.Move(_moveSpeed * Time.deltaTime * new Vector3(0, y, 0).normalized);
                _buildItem.Turn(_turnSpeed * x * Time.deltaTime);
                return;
            }

            var direction = new Vector3(x, 0, y).normalized;
            _buildItem.Move(_moveSpeed * Time.deltaTime * direction);
        }

        void UpdateCamera()
        {
            var direction = _cameraTransform.forward.normalized * -1;

            _cameraTransform.position = _buildItem.Position + direction * _cameraDistance;
        }
    }
}