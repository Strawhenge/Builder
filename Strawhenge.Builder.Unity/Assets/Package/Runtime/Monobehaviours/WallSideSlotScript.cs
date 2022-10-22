using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class WallSideSlotScript : BaseSlotScript
    {
        [SerializeField] bool _canRotate;
        [SerializeField] float[] _presetAngles;

        public bool CanRotate => _canRotate;

        public IReadOnlyList<float> PresetAngles => _presetAngles;
    }
}