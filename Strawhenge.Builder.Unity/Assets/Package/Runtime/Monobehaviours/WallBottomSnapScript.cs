using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Common.Ranges;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class WallBottomSnapScript : BaseSnapScript<HorizontalSnap, WallBottomSlotScript>
    {
        protected override HorizontalSnap Map(SnapPoint snapPoint, WallBottomSlotScript snapSlotScript)
        {
            return new HorizontalSnap(snapPoint, snapSlotScript.SnapSlotAnchor, FloatRange.Zero, canFlip: true);
        }
    }
}