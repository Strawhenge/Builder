using Strawhenge.Builder.Unity.BuildItems.SlotSettings;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/FloorEdge")]
    public class FloorEdgeSlotSettingsScriptableObject : ScriptableObject, IFloorEdgeSlotSettings
    {
        [SerializeField] bool _canFlip;
        [SerializeField] SerializedFloatRange _tiltRange;

        public bool CanFlip => _canFlip;

        public FloatRange TiltRange => _tiltRange.Value;
    }
}