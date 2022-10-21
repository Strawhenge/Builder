using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class WallSideSnapScript : BaseSnapScript<VerticalSnap, WallSideSlotScript>
    {
        protected override VerticalSnap Map(SnapPoint snapPoint, WallSideSlotScript snapSlotScript) =>
            new VerticalSnap(snapPoint, snapSlotScript.SnapSlotAnchor);
    }
}