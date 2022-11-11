using Strawhenge.Builder.Unity.BuildItems.Snapping;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class FloorEdgeSnapScript : BaseSnapScript<HorizontalSnap, FloorEdgeSlotScript>
    {
        protected override HorizontalSnap Map(SnapPoint snapPoint, FloorEdgeSlotScript snapSlotScript) =>
            new HorizontalSnap(
                snapPoint,
                snapSlotScript.SnapSlotAnchor,
                snapSlotScript.TiltRange,
                (-1, 1),
                snapSlotScript.CanFlip);
    }
}