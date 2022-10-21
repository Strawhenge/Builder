using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class HorizontalSnap
    {
        readonly SnapPoint _snapPoint;
        readonly Transform _snappedTo;
        readonly FloatRange _turnRange;

        float _angle;
        bool _isFlipped;

        public HorizontalSnap(SnapPoint snapPoint, Transform snappedTo, FloatRange turnRange, bool canFlip)
        {
            _snapPoint = snapPoint;
            _snappedTo = snappedTo;
            _turnRange = turnRange;

            CanFlip = canFlip;
        }

        public bool CanFlip { get; }

        public void Snap()
        {
            _snapPoint.SetPosition(_snappedTo.position);
            _snapPoint.SetRotation(
                _snappedTo.rotation * Quaternion.AngleAxis(180, Vector3.up));
        }

        public void Slide(float amount)
        {
            _snapPoint.SetPosition(
                _snapPoint.Position + _snappedTo.right * amount);
        }

        public void Turn(float amount)
        {
            _angle = _turnRange.Clamp(_angle + amount);
            ApplyRotationAngle();
        }

        public void Flip()
        {
            if (!CanFlip)
                return;

            _isFlipped = !_isFlipped;
            ApplyRotationAngle();
        }

        void ApplyRotationAngle()
        {
            var relativeAngle = _angle + Vector3.Angle(_snappedTo.forward, Vector3.up) - 90;

            var rotation = _snappedTo.rotation *
                           Quaternion.AngleAxis(_isFlipped ? -relativeAngle : relativeAngle, Vector3.right) *
                           Quaternion.AngleAxis(_isFlipped ? 0 : 180, Vector3.up);

            _snapPoint.SetRotation(rotation);
        }
    }
}