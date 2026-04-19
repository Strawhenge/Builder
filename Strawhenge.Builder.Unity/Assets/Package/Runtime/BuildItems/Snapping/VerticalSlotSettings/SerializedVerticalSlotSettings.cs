using System;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    [Serializable]
    public class SerializedVerticalSlotSettings : IVerticalSlotSettings
    {
        [SerializeField] bool _canRotate;
        [SerializeField] float[] _presetAngles;

        public bool CanRotate => _canRotate;

        public IEnumerable<float> PresetAngles => _presetAngles ?? Array.Empty<float>();
    }
}

