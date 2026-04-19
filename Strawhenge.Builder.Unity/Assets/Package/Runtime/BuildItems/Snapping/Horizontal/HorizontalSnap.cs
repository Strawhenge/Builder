using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class HorizontalSnap
    {
        readonly SnapPoint _snapPoint;
        readonly Transform _snappedTo;
        readonly FloatRange _tiltRange;
        readonly SlideAmount _slideAmount;

        float _angle;
        bool _isFlipped;

        public HorizontalSnap(
            SnapPoint snapPoint,
            Transform snappedTo,
            FloatRange tiltRange,
            FloatRange slideRange,
            bool canFlip)
        {
            _snapPoint = snapPoint;
            _snappedTo = snappedTo;
            _slideAmount = new SlideAmount(slideRange);

            _angle = Vector3.Angle(_snappedTo.forward, Vector3.up) - 90;
            _tiltRange = new FloatRange(tiltRange.Min - _angle, tiltRange.Max - _angle);

            CanFlip = canFlip;
        }

        public bool CanFlip { get; }

        public Transform GetSnappedToTransform() => _snappedTo;
        
        public void Snap()
        {
            _snapPoint.SetPosition(_snappedTo.position);
            _snapPoint.SetRotation(
                _snappedTo.rotation * Quaternion.AngleAxis(180, Vector3.up));
        }

        public void Slide(float amount)
        {
            if (!_slideAmount.Slide(amount, out amount))
                return;

            _snapPoint.SetPosition(
                _snapPoint.Position + _snappedTo.right * amount);
        }

        public void Tilt(float amount)
        {
            _angle = _tiltRange.Clamp(_angle + amount);
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
            var rotation = _snappedTo.rotation *
                           Quaternion.AngleAxis(_isFlipped ? -_angle : _angle, Vector3.right) *
                           Quaternion.AngleAxis(_isFlipped ? 0 : 180, Vector3.up);

            _snapPoint.SetRotation(rotation);
        }
    }
}