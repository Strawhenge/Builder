using Strawhenge.Common.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class VerticalSnap
    {
        readonly SnapPoint _snapPoint;
        readonly Transform _snappedTo;
        readonly Cycle<float> _presetAngles;
        readonly SlideAmount _slideAmount = new SlideAmount(-1, 1);

        float _angle;

        public VerticalSnap(
            SnapPoint snapPoint,
            Transform snappedTo,
            bool canRotate,
            IEnumerable<float> presetAngles)
        {
            _snapPoint = snapPoint;
            _snappedTo = snappedTo;

            _presetAngles = new Cycle<float>(0, presetAngles);

            CanRotate = canRotate;
        }

        public bool CanRotate { get; }

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
                _snapPoint.Position + _snappedTo.up * amount);
        }

        public void Turn(float amount)
        {
            if (!CanRotate)
                return;

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