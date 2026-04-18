using System;

namespace Strawhenge.Builder.Unity.BuildItems.Controls.VerticalSnap
{
    public class VerticalSnapControls
    {
        readonly float _turnSpeed;
        readonly float _slideSpeed;

        Snapping.VerticalSnap _snap;

        internal VerticalSnapControls(IVerticalSnapControlsSettings settings)
        {
            _turnSpeed = settings.TurnSpeed;
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

        public void Turn(float input) => _snap.Turn(input * _turnSpeed);

        public void TurnNext() => _snap.TurnNext();

        public void TurnPrevious() => _snap.TurnPrevious();

        public void Slide(float input) => _snap.Slide(input * _slideSpeed);

        internal void ControlOn(Snapping.VerticalSnap snap)
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