using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Serialization;
using System;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.SlotSettings
{
    [Serializable]
    public class SerializedFloorEdgeSlotSettings : IFloorEdgeSlotSettings
    {
        [SerializeField] bool _canFlip;
        [SerializeField] SerializedFloatRange _tiltRange;

        public bool CanFlip => _canFlip;

        public FloatRange TiltRange => _tiltRange?.Value ?? FloatRange.Zero;
    }
}