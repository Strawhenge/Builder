using Strawhenge.Builder.Unity.BuildItems.SlotSettings;
using Strawhenge.Common.Unity.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping.WallSide
{
    public class WallSideSlotScript : BaseSlotScript
    {
        [SerializeField] SerializedSource<
            IWallSideSlotSettings, SerializedWallSideSlotSettings, WallSideSlotSettingsScriptableObject> _settings;

        internal bool CanRotate => _settings.GetValue().CanRotate;

        internal IEnumerable<float> PresetAngles => _settings.GetValue().PresetAngles;

        internal override float? GetSlideLength() => transform.lossyScale.y;
    }
}