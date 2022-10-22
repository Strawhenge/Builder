using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/WallSide")]
    public class WallSideSlotSettingsScriptableObject : ScriptableObject
    {
        [SerializeField] bool _canRotate;
        [SerializeField] float[] _presetAngles;

        public bool CanRotate => _canRotate;

        public IEnumerable<float> PresetAngles => _presetAngles;
    }
}