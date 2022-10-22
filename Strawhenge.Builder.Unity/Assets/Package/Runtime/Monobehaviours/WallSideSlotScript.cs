using Strawhenge.Builder.Unity.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class WallSideSlotScript : BaseSlotScript
    {
        [SerializeField] WallSideSlotSettingsScriptableObject _settings;

        public bool CanRotate => _settings != null && _settings.CanRotate;

        public IEnumerable<float> PresetAngles => _settings == null
            ? Array.Empty<float>()
            : _settings.PresetAngles;
    }
}