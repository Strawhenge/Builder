using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class VerticalSnapInputScript : MonoBehaviour
    {
        [SerializeField] ControlsScript _controls;

        VerticalSnapControls _verticalSnapControls;

        void Awake()
        {
            ComponentRefHelper
                .EnsureSceneComponent(ref _controls, nameof(ControlsScript), this);

            _verticalSnapControls = _controls.VerticalSnapControls;
            enabled = _verticalSnapControls.IsEnabled;
            _verticalSnapControls.Enabled += () => enabled = true;
            _verticalSnapControls.Disabled += () => enabled = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _verticalSnapControls.Cancel();
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _verticalSnapControls.Release();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _verticalSnapControls.Place();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _verticalSnapControls.TurnNext();
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Mathf.Abs(x) > 0.1f)
            {
                _verticalSnapControls.Turn(x * Time.deltaTime);
            }

            if (Mathf.Abs(y) > 0.01f)
            {
                _verticalSnapControls.Slide(y * Time.deltaTime);
            }
        }
    }
}