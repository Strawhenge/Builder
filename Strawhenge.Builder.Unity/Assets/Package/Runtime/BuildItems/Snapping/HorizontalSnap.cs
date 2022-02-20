using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class HorizontalSnap
    {
        readonly SnapPoint snapPoint;
        readonly Transform snappedTo;
        readonly FloatRange turnRange;

        float angle;
        bool isFlipped;

        public HorizontalSnap(SnapPoint snapPoint, Transform snappedTo, FloatRange turnRange)
        {
            this.snapPoint = snapPoint;
            this.snappedTo = snappedTo;
            this.turnRange = turnRange;
        }

        public void Snap()
        {
            snapPoint.SetPosition(snappedTo.position);
            snapPoint.SetRotation(snappedTo.rotation);
        }

        public void Slide(float amount)
        {
            snapPoint.SetPosition(
                snapPoint.Position + snappedTo.right * amount);
        }

        public void Turn(float amount)
        {
            angle = turnRange.Clamp(angle + amount);
            ApplyRotationAngle();
        }

        public void Flip()
        {
            isFlipped = !isFlipped;
            ApplyRotationAngle();
        }

        void ApplyRotationAngle()
        {
            var relativeAngle = angle + Vector3.Angle(snappedTo.forward, Vector3.up) - 90;

            var rotation = snappedTo.rotation *
                Quaternion.AngleAxis(isFlipped ? -relativeAngle : relativeAngle, Vector3.right) *
                Quaternion.AngleAxis(isFlipped ? 180 : 0, Vector3.up);

            snapPoint.SetRotation(rotation);
        }
    }
}