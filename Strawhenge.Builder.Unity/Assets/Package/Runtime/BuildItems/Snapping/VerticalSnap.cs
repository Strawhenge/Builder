using Strawhenge.Common.Collections;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class VerticalSnap
    {
        readonly SnapPoint _snapPoint;
        readonly Transform _snappedTo;
        readonly Cycle<float> _presetAngles;

        float _angle;

        public VerticalSnap(SnapPoint snapPoint, Transform snappedTo)
        {
            _snapPoint = snapPoint;
            _snappedTo = snappedTo;

            _presetAngles = new Cycle<float>(0, 90, 270);
        }

        public void Snap()
        {
            _snapPoint.SetPosition(_snappedTo.position);
            _snapPoint.SetRotation(
                _snappedTo.rotation * Quaternion.AngleAxis(180, Vector3.up));
        }

        public void Slide(float amount)
        {
            _snapPoint.SetPosition(
                _snapPoint.Position + _snappedTo.up * amount);
        }

        public void Turn(float amount)
        {
            _angle += amount;
            ApplyRotationAngle();
        }

        public void TurnPrevious()
        {
            _angle = _presetAngles.Previous();
            ApplyRotationAngle();
        }

        public void TurnNext()
        {
            _angle = _presetAngles.Next();
            ApplyRotationAngle();
        }

        void ApplyRotationAngle()
        {
            var rotation = _snappedTo.rotation * Quaternion.AngleAxis(_angle + 180, Vector3.up);
            _snapPoint.SetRotation(rotation);
        }
    }
}