using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class BuildItemInputScript : MonoBehaviour
    {
        [SerializeField] ControlsScript _controls;

        BuildItemControls _buildItemControls;

        void Awake()
        {
            ComponentRefHelper
                .EnsureSceneComponent(ref _controls, nameof(_controls), this);

            _buildItemControls = _controls.BuildItemControls;
            enabled = _buildItemControls.IsEnabled;
            _buildItemControls.Enabled += () => enabled = true;
            _buildItemControls.Disabled += () => enabled = false;
        }

        void Update()
        {
            ManageBlueprintMovement();
            ManageClippingToggle();

            if (Input.GetKeyDown(KeyCode.Return))
                _buildItemControls.Place();

            if (Input.GetKeyDown(KeyCode.RightShift))
                _buildItemControls.Snap();

            if (Input.GetKeyDown(KeyCode.Escape))
                _buildItemControls.Cancel();

            if (Input.GetKeyDown(KeyCode.Backspace))
                _buildItemControls.Scrap();
        }

        void ManageBlueprintMovement()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _buildItemControls.Move(new Vector3(0, y, 0));
                _buildItemControls.Turn(x * Time.deltaTime);
                return;
            }

            _buildItemControls.Move(new Vector3(x, 0, y).normalized);
        }

        void ManageClippingToggle()
        {
            if (!Input.GetKeyDown(KeyCode.CapsLock))
                return;

            _buildItemControls.ClippingToggle();
        }
    }
}