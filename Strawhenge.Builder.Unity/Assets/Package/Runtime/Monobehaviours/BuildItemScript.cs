using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Builder.Unity.ScriptableObjects;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuildItemScript : MonoBehaviour
    {
        [SerializeField] SerializableComponentQuantity[] _scrapComponents;
        [SerializeField] BuildItemSettingsScriptableObject _settings;
        [SerializeField] EventScriptableObject[] _onArrangeEvents;
        [SerializeField] EventScriptableObject[] _onPlaceEvents;

        SnapSlotToggle _snapSlotToggle;
        ArrangeBuildItem _arrangeBuildItem;

        public IArrangeBuildItem Arrange => _arrangeBuildItem;

        public ScrapValue ScrapValue { get; private set; }

        public void SetArranging()
        {
            _snapSlotToggle.Snaps();

            foreach (var @event in _onArrangeEvents)
                @event.Invoke(gameObject);

            _arrangeBuildItem.Enable();
        }

        public void SetPlaced()
        {
            _arrangeBuildItem.Disable();
            _snapSlotToggle.Slots();

            foreach (var @event in _onPlaceEvents)
                @event.Invoke(gameObject);
        }

        void Awake()
        {
            var verticalSnapPoints = GetComponentsInChildren<BaseSnapScript<VerticalSnap>>();
            var horizontalSnapPoints = GetComponentsInChildren<BaseSnapScript<HorizontalSnap>>();
            var slotPoints = GetComponentsInChildren<BaseSlotScript>();

            _snapSlotToggle = new SnapSlotToggle(verticalSnapPoints, horizontalSnapPoints, slotPoints);

            _arrangeBuildItem = new ArrangeBuildItem(
                transform,
                GetTiltRangeFromSettings(),
                getAvailableVerticalSnaps: () => verticalSnapPoints.SelectMany(x => x.GetAvailableSnaps()).ToArray(),
                getAvailableHorizontalSnaps: () => horizontalSnapPoints.SelectMany(x => x.GetAvailableSnaps()));

            ScrapValue = new ScrapValue(_scrapComponents.Select(
                x => new ComponentQuantity(new Component(x.Component.Identifier), x.Quantity)));
        }

        FloatRange GetTiltRangeFromSettings()
        {
            var settings = _settings as IBuildItemSettings;

            if (FloatRange.IsValidRange(settings.MinTiltAngle, settings.MaxTiltAngle))
                return (settings.MinTiltAngle, settings.MaxTiltAngle);

            Debug.LogWarning(
                $"Invalid tilt angle settings. {nameof(settings.MinTiltAngle)}: {settings.MinTiltAngle}, {nameof(settings.MaxTiltAngle)}: {settings.MaxTiltAngle}",
                context: this);

            return (0, 0);
        }
    }
}