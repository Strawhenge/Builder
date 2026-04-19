using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    [CreateAssetMenu(menuName = "Strawhenge/Builder/SlotSettings/Vertical")]
    public class VerticalSlotSettingsScriptableObject : ScriptableObject, IVerticalSlotSettings
    {
        [SerializeField] bool _canRotate;
        [SerializeField] float[] _presetAngles;

        public bool CanRotate => _canRotate;

        public IEnumerable<float> PresetAngles => _presetAngles;
    }
}

