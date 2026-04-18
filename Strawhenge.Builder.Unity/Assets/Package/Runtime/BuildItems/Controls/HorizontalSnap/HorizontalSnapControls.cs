using System;

namespace Strawhenge.Builder.Unity.BuildItems.Controls.HorizontalSnap
{
    public class HorizontalSnapControls
    {
        readonly float _tiltSpeed;
        readonly float _slideSpeed;

        Snapping.HorizontalSnap _snap;

        internal HorizontalSnapControls(IHorizontalSnapControlsSettings settings)
        {
            _tiltSpeed = settings.TiltSpeed;
            _slideSpeed = settings.SlideSpeed;
        }

        public event Action Enabled;

        public event Action Disabled;

        internal event Action Placed;

        internal event Action Released;

        internal event Action Cancelled;

        public bool IsEnabled => _snap != null;

        public void Place() => Placed?.Invoke();

        public void Cancel() => Cancelled?.Invoke();

        public void Release() => Released?.Invoke();

        public void Flip() => _snap.Flip();

        public void Tilt(float input) => _snap.Tilt(input * _tiltSpeed);

        public void Slide(float input) => _snap.Slide(input * _slideSpeed);

        internal void ControlOn(Snapping.HorizontalSnap snap)
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