using Strawhenge.Builder.Unity.BuildItems.Snapping;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class WallSideSnapScript : BaseSnapScript<VerticalSnap, WallSideSlotScript>
    {
        internal override float? GetSlideLength() => Transform.lossyScale.y;

        protected override VerticalSnap Map(SnapPoint snapPoint, WallSideSlotScript snapSlotScript) =>
            new VerticalSnap(
                snapPoint,
                snapSlotScript.SnapSlotAnchor,
                snapSlotScript.CanRotate,
                snapSlotScript.PresetAngles,
                SlideRangeHelper.GetRange(this, snapSlotScript));
    }
}