using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class FloorEdgeSnapScript : BaseSnapScript<FloorEdgeSnap, FloorEdgeSlotScript>
    {
        [SerializeField] HorizontalSnapSettingsScriptableObject _settings;
        FloatRange _turnRange;

        protected override FloorEdgeSnap Map(SnapPoint snapPoint, FloorEdgeSlotScript snapSlotScript) =>
            new FloorEdgeSnap(snapPoint, snapSlotScript.SnapSlotAnchor, _turnRange, snapSlotScript.CanFlip);

        protected override void AfterAwake()
        {
            _turnRange = GetTurnRangeFromSettings(_settings);
        }

        FloatRange GetTurnRangeFromSettings(IHorizontalSnapSettings settings)
        {
            if (!FloatRange.IsValidRange(settings.MinTurnAngle, settings.MaxTurnAngle))
            {
                Debug.LogWarning(
                    $"Invalid tilt angle settings. {nameof(settings.MinTurnAngle)}: {settings.MinTurnAngle}, {nameof(settings.MaxTurnAngle)}: {settings.MaxTurnAngle}",
                    context: this);
                return (0, 0);
            }

            return (settings.MinTurnAngle, settings.MaxTurnAngle);
        }
    }
}