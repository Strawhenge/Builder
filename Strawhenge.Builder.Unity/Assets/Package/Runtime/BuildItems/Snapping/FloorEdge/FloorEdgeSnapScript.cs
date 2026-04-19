namespace Strawhenge.Builder.Unity.BuildItems.Snapping.FloorEdge
{
    public class FloorEdgeSnapScript : BaseSnapScript<HorizontalSnap, FloorEdgeSlotScript>
    {
        internal override float? GetSlideLength() => transform.lossyScale.x;

        protected override HorizontalSnap Map(SnapPoint snapPoint, FloorEdgeSlotScript snapSlotScript) =>
            new HorizontalSnap(
                snapPoint,
                snapSlotScript.SnapSlotAnchor,
                snapSlotScript.TiltRange,
                SlideRangeHelper.GetRange(this, snapSlotScript),
                snapSlotScript.CanFlip);
    }
}