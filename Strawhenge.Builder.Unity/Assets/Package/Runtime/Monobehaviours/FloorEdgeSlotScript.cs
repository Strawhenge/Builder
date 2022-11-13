using Strawhenge.Builder.Unity.BuildItems.SlotSettings;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class FloorEdgeSlotScript : BaseSlotScript
    {
        [SerializeField] SerializedSource<
            IFloorEdgeSlotSettings, SerializedFloorEdgeSlotSettings, FloorEdgeSlotSettingsScriptableObject> _settings;

        internal bool CanFlip => _settings.GetValue().CanFlip;

        internal FloatRange TiltRange => _settings.GetValue().TiltRange;

        internal override float? GetSlideLength() => Transform.lossyScale.x;
    }
}