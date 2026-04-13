using Strawhenge.Builder.Unity.BuildItems.Snapping;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class FloorEdgeSnapScript : BaseSnapScript<HorizontalSnap, FloorEdgeSlotScript>
    {
        internal override float? GetSlideLength() => Transform.lossyScale.x;

        protected override HorizontalSnap Map(SnapPoint snapPoint, FloorEdgeSlotScript snapSlotScript) =>
            new HorizontalSnap(
                snapPoint,
                snapSlotScript.SnapSlotAnchor,
                snapSlotScript.TiltRange,
                SlideRangeHelper.GetRange(this, snapSlotScript),
                snapSlotScript.CanFlip);
    }
}