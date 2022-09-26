using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.ScriptableObjects;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuildItemScript : MonoBehaviour
    {
        [SerializeField]
        SerializableComponentQuantity[] _scrapComponents;

        [SerializeField]
        BuildItemSettingsScriptableObject settings;

        public IBuildItemPreview BuildItemPreview { get; private set; }

        public ScrapValue ScrapValue { get; private set; }

        void Awake()
        {
            var verticalSnapPoints = GetComponentsInChildren<VerticalSnapScript>();
            var horizontalSnapPoints = GetComponentsInChildren<HorizontalSnapScript>();

            BuildItemPreview = new BuildItemPreview(
                transform,
                GetTiltRangeFromSettings(),
                getAvailableVerticalSnaps: () => verticalSnapPoints.SelectMany(x => x.GetAvailableSnaps()).ToArray(),
                getAvailableHorizontalSnaps: () => horizontalSnapPoints.SelectMany(x => x.GetAvailableSnaps()).ToArray());

            ScrapValue = new ScrapValue(
                _scrapComponents.Select(x =>
                {
                    return new ComponentQuantity(new Component(x.Component.Identifier), x.Quantity);
                }));
        }

        FloatRange GetTiltRangeFromSettings()
        {
            var settings = this.settings as IBuildItemSettings;

            if (!FloatRange.IsValidRange(settings.MinTiltAngle, settings.MaxTiltAngle))
            {
                Debug.LogWarning(
                    $"Invalid tilt angle settings. {nameof(settings.MinTiltAngle)}: {settings.MinTiltAngle}, {nameof(settings.MaxTiltAngle)}: {settings.MaxTiltAngle}",
                    context: this);
                return (0, 0);
            }

            return (settings.MinTiltAngle, settings.MaxTiltAngle);
        }
    }
}