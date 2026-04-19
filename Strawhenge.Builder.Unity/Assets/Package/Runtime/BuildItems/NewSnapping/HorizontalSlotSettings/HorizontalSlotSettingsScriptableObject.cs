using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/Horizontal")]
    public class HorizontalSlotSettingsScriptableObject : ScriptableObject, IHorizontalSlotSettings
    {
        [SerializeField] bool _canFlip;
        [SerializeField] SerializedFloatRange _tiltRange;

        public bool CanFlip => _canFlip;

        public FloatRange TiltRange => _tiltRange.Value;
    }
}

