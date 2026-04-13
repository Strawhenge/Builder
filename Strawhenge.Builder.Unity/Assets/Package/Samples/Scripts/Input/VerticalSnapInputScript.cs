using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Sample.Input
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
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            {
                _verticalSnapControls.Cancel();
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.RightShift))
            {
                _verticalSnapControls.Release();
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Return))
            {
                _verticalSnapControls.Place();
                return;
            }

            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            {
                _verticalSnapControls.TurnNext();
                return;
            }

            var x = UnityEngine.Input.GetAxis("Horizontal");
            var y = UnityEngine.Input.GetAxis("Vertical");

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