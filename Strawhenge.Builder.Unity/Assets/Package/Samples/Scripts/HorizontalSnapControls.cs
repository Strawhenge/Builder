using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class HorizontalSnapControls : MonoBehaviour, IHorizontalSnapControls
    {
        [SerializeField] float _turnSpeed;
        [SerializeField] float _moveSpeed;

        HorizontalSnap _snap;

        public event Action Place;
        public event Action Release;
        public event Action Cancel;

        public void ControlOff()
        {
            enabled = false;
            _snap = null;
        }

        public void ControlOn(HorizontalSnap snap)
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
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cancel?.Invoke();
                return;
            }

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
                _snap.Flip();
                return;
            }

            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Mathf.Abs(y) > 0.1f)
            {
                _snap.Tilt(-y * Time.deltaTime * _turnSpeed);
            }

            if (Mathf.Abs(x) > 0.01f)
            {
                _snap.Slide(x * _moveSpeed * Time.deltaTime);
            }
        }
    }
}
