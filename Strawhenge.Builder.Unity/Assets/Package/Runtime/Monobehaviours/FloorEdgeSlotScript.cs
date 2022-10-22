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
            IFloorEdgeSlotSettings, SerializableFloorEdgeSlotSettings, FloorEdgeSlotSettingsScriptableObject> _settings;

        public bool CanFlip => _settings.GetValue().CanFlip;

        public FloatRange TiltRange => _settings.GetValue().TiltRange;
    }
}