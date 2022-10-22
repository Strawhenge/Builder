using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class FloorEdgeSnapScript : BaseSnapScript<HorizontalSnap, FloorEdgeSlotScript>
    {
        protected override HorizontalSnap Map(SnapPoint snapPoint, FloorEdgeSlotScript snapSlotScript) =>
            new HorizontalSnap(
                snapPoint, 
                snapSlotScript.SnapSlotAnchor, 
                snapSlotScript.TiltRange,
                snapSlotScript.CanFlip);
    }
}