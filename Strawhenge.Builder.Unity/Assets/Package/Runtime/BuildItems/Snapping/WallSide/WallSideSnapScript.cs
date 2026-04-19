namespace Strawhenge.Builder.Unity.BuildItems.Snapping.WallSide
{
    public class WallSideSnapScript : BaseSnapScript<VerticalSnap, WallSideSlotScript>
    {
        internal override float? GetSlideLength() => transform.lossyScale.y;

        protected override VerticalSnap Map(SnapPoint snapPoint, WallSideSlotScript snapSlotScript) =>
            new VerticalSnap(
                snapPoint,
                snapSlotScript.SnapSlotAnchor,
                snapSlotScript.CanRotate,
                snapSlotScript.PresetAngles,
                SlideRangeHelper.GetRange(this, snapSlotScript));
    }
}