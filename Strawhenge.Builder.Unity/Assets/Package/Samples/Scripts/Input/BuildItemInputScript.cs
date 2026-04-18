using Strawhenge.Builder.Unity.BuildItems.Controls.BuildItem;
using Strawhenge.Builder.Unity.Manager;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Sample.Input
{
    public class BuildItemInputScript : MonoBehaviour
    {
        [SerializeField] BuilderScript _builder;

        BuildItemControls _buildItemControls;

        void Awake()
        {
            ComponentRefHelper
                .EnsureSceneComponent(ref _builder, nameof(_builder), this);

            _buildItemControls = _builder.BuilderManager.Controls.BuildItem;
            enabled = _buildItemControls.IsEnabled;
            _buildItemControls.Enabled += () => enabled = true;
            _buildItemControls.Disabled += () => enabled = false;
        }

        void Update()
        {
            ManageBlueprintMovement();
            ManageClippingToggle();

            if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
                _buildItemControls.Place();

            if (UnityEngine.Input.GetKeyDown(KeyCode.RightShift))
                _buildItemControls.Snap();

            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                _buildItemControls.Cancel();

            if (UnityEngine.Input.GetKeyDown(KeyCode.Backspace))
                _buildItemControls.Scrap();
        }

        void ManageBlueprintMovement()
        {
            var x = UnityEngine.Input.GetAxis("Horizontal");
            var y = UnityEngine.Input.GetAxis("Vertical");

            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                _buildItemControls.Move(new Vector3(0, y, 0));
                _buildItemControls.Turn(x * Time.deltaTime);
                return;
            }

            _buildItemControls.Move(new Vector3(x, 0, y).normalized);
        }

        void ManageClippingToggle()
        {
            if (!UnityEngine.Input.GetKeyDown(KeyCode.CapsLock))
                return;

            _buildItemControls.ClippingToggle();
        }
    }
}