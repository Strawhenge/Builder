using System;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.SlotSettings
{
    [Serializable]
    public class SerializedWallSideSlotSettings : IWallSideSlotSettings
    {
        [SerializeField] bool _canRotate;
        [SerializeField] float[] _presetAngles;

        public bool CanRotate => _canRotate;

        public IEnumerable<float> PresetAngles => _presetAngles;
    }
}