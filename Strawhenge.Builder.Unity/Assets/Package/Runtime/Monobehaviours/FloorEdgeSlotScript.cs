using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class FloorEdgeSlotScript : BaseSlotScript
    {
        [SerializeField] FloorEdgeSlotSettingsScriptableObject _settings;

        public bool CanFlip => _settings != null && _settings.CanFlip;

        public FloatRange TiltRange
        {
            get
            {
                if (_settings == null)
                    return FloatRange.Zero;

                if (FloatRange.IsValidRange(_settings.MinTiltAngle, _settings.MaxTiltAngle))
                    return new FloatRange(_settings.MinTiltAngle, _settings.MaxTiltAngle);

                Debug.LogError($"Tilt range {_settings.MinTiltAngle} - {_settings.MaxTiltAngle} is invalid.", this);
                return FloatRange.Zero;
            }
        }
    }
}