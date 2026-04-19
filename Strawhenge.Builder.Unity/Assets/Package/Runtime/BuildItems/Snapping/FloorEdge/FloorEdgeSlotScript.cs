using Strawhenge.Builder.Unity.BuildItems.SlotSettings;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping.FloorEdge
{
    public class FloorEdgeSlotScript : BaseSlotScript
    {
        [SerializeField] SerializedSource<
            IFloorEdgeSlotSettings, SerializedFloorEdgeSlotSettings, FloorEdgeSlotSettingsScriptableObject> _settings;

        internal bool CanFlip => _settings.GetValue().CanFlip;

        internal FloatRange TiltRange => _settings.GetValue().TiltRange;

        internal override float? GetSlideLength() => transform.lossyScale.x;
    }
}