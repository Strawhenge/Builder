using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class WallSideSnapScript : BaseSnapScript<WallSideSnap, WallSideSlotScript>
    {
        protected override WallSideSnap Map(SnapPoint snapPoint, WallSideSlotScript snapSlotScript) =>
            new WallSideSnap(snapPoint, snapSlotScript.SnapSlotAnchor);
    }
}