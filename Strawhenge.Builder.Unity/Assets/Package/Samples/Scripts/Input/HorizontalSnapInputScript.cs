using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class HorizontalSnapInputScript : MonoBehaviour
    {
        [SerializeField] ControlsScript _controls;

        HorizontalSnapControls _horizontalSnapControls;

        void Awake()
        {
            ComponentRefHelper
                .EnsureSceneComponent(ref _controls, nameof(ControlsScript), this);

            _horizontalSnapControls = _controls.HorizontalSnapControls;
            enabled = _horizontalSnapControls.IsEnabled;
            _horizontalSnapControls.Enabled += () => enabled = true;
            _horizontalSnapControls.Disabled += () => enabled = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _horizontalSnapControls.Cancel();
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                _horizontalSnapControls.Release();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                _horizontalSnapControls.Place();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _horizontalSnapControls.Flip();
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Mathf.Abs(y) > 0.1f)
            {
                _horizontalSnapControls.Tilt(-y * Time.deltaTime);
            }

            if (Mathf.Abs(x) > 0.01f)
            {
                _horizontalSnapControls.Slide(x * Time.deltaTime);
            }
        }
    }
}