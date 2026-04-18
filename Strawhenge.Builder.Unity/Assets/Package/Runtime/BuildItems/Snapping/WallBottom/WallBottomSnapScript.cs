namespace Strawhenge.Builder.Unity.BuildItems.Snapping.WallBottom
{
    public class WallBottomSnapScript : BaseSnapScript<HorizontalSnap, WallBottomSlotScript>
    {
        internal override float? GetSlideLength() => Transform.lossyScale.x;

        protected override HorizontalSnap Map(SnapPoint snapPoint, WallBottomSlotScript snapSlotScript)
        {
            return new HorizontalSnap(
                snapPoint,
                snapSlotScript.SnapSlotAnchor,
                snapSlotScript.TiltRange,
                SlideRangeHelper.GetRange(this, snapSlotScript),
                canFlip: true);
        }
    }
}