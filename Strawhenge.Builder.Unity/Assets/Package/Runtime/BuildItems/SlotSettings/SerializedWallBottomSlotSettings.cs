using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.SlotSettings
{
    [Serializable]
    public class SerializedWallBottomSlotSettings : IWallBottomSlotSettings
    {
        [SerializeField] SerializedFloatRange _tiltRange;

        public FloatRange TiltRange => _tiltRange.Value;
    }
}