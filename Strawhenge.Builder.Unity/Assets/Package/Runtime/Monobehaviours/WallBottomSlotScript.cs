using Strawhenge.Builder.Unity.BuildItems.SlotSettings;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class WallBottomSlotScript : BaseSlotScript
    {
        [SerializeField] SerializedSource<
                IWallBottomSlotSettings, SerializedWallBottomSlotSettings, WallBottomSlotSettingsScriptableObject>
            _settings;

        public FloatRange TiltRange => _settings.GetValue().TiltRange;
    }
}