using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class HorizontalSnapControls
    {
        readonly float _tiltSpeed;
        readonly float _slideSpeed;

        HorizontalSnap _snap;

        public HorizontalSnapControls(HorizontalSnapControlsSettings settings)
        {
            _tiltSpeed = settings.TiltSpeed;
            _slideSpeed = settings.SlideSpeed;
        }

        public event Action Enabled;

        public event Action Disabled;

        internal event Action Place;

        internal event Action Release;

        internal event Action Cancel;

        public bool IsEnabled => _snap != null;

        public void InvokePlace() => Place?.Invoke();

        public void InvokeCancel() => Cancel?.Invoke();

        public void InvokeRelease() => Release?.Invoke();

        public void Flip() => _snap.Flip();

        public void Tilt(float input) => _snap.Tilt(input * _tiltSpeed);

        public void Slide(float input) => _snap.Slide(input * _slideSpeed);

        internal void ControlOn(HorizontalSnap snap)
        {
            _snap = snap;
            Enabled?.Invoke();
        }

        internal void ControlOff()
        {
            _snap = null;
            Disabled?.Invoke();
        }
    }
}