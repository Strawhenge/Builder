using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class VerticalSnapControls : MonoBehaviour, IWallSideSnapControls
    {
        [SerializeField] float _turnSpeed;
        [SerializeField] float _moveSpeed;

        public event Action Place;
        public event Action Release;

        WallSideSnap _snap;

        public void ControlOff()
        {
            enabled = false;
            _snap = null;
        }

        public void ControlOn(WallSideSnap snap)
        {
            _snap = snap;
            enabled = true;
        }

        void OnEnable()
        {
            if (_snap == null)
                enabled = false;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                Release?.Invoke();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                Place?.Invoke();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _snap.TurnNext();
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Mathf.Abs(x) > 0.1f)
            {
                _snap.Turn(x * Time.deltaTime * _turnSpeed);
            }

            if (Mathf.Abs(y) > 0.01f)
            {
                _snap.Slide(y * _moveSpeed * Time.deltaTime);
            }
        }
    }
}
