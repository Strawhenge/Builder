using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    public class WallBottomSlotScript : BaseSlotScript
    {
        [SerializeField] WallBottomSlotSettingsScriptableObject _settings;

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