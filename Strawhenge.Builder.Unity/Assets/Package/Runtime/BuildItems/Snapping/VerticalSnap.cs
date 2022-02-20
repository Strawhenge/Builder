using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class VerticalSnap
    {
        readonly SnapPoint snapPoint;
        readonly Transform snappedTo;
        readonly Cycle<float> presetAngles;

        float angle;

        public VerticalSnap(SnapPoint snapPoint, Transform snappedTo)
        {
            this.snapPoint = snapPoint;
            this.snappedTo = snappedTo;

            presetAngles = new Cycle<float>(0, 90, 270);
        }

        public void Snap()
        {
            snapPoint.SetPosition(snappedTo.position);
            snapPoint.SetRotation(snappedTo.rotation);
        }

        public void Slide(float amount)
        {
            snapPoint.SetPosition(
                snapPoint.Position + snappedTo.up * amount);
        }

        public void Turn(float amount)
        {
            angle += amount;
            ApplyRotationAngle();
        }

        public void TurnPrevious()
        {
            angle = presetAngles.Previous();
            ApplyRotationAngle();
        }

        public void TurnNext()
        {
            angle = presetAngles.Next();
            ApplyRotationAngle();
        }

        void ApplyRotationAngle()
        {
            var rotation = snappedTo.rotation * Quaternion.AngleAxis(angle, Vector3.up);
            snapPoint.SetRotation(rotation);
        }
    }
}