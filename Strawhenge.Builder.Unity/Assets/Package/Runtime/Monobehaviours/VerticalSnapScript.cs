using Strawhenge.Builder.Unity.BuildItems.Snapping;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class VerticalSnapScript : BaseSnapScript<VerticalSnap>
    {
        protected override VerticalSnap Map(SnapPoint snapPoint, Transform snapSlot) =>
            new VerticalSnap(snapPoint, snapSlot);
    }
}