using Strawhenge.Builder.Unity.BuildItems.SlotSettings;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/WallBottom")]
    public class WallBottomSlotSettingsScriptableObject : ScriptableObject, IWallBottomSlotSettings
    {
        [SerializeField] SerializedFloatRange _tiltRange;

        public FloatRange TiltRange => _tiltRange.Value;
    }
}