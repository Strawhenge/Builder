using Strawhenge.Builder.Unity.BuildItems;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.Data;
using Strawhenge.Common.Unity.Events;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public class BuildItemScript : MonoBehaviour
    {
        [SerializeField] SerializableComponentQuantity[] _scrapComponents;
        [SerializeField] EventContainer[] _onArrangeEvents;
        [SerializeField] EventContainer[] _onPlaceEvents;
        [SerializeField] Collider[] _arrangeColliders;

        SnapSlotToggle _snapSlotToggle;

        public IArrangeBuildItem Arrange { get; private set; }

        public ScrapValue ScrapValue { get; private set; }

        public void SetArranging()
        {
            _snapSlotToggle.Snaps();

            foreach (var @event in _onArrangeEvents)
                @event.Invoke(gameObject);
        }

        public void SetPlaced()
        {
            _snapSlotToggle.Slots();

            foreach (var @event in _onPlaceEvents)
                @event.Invoke(gameObject);
        }

        void Awake()
        {
            var verticalSnapPoints = GetComponentsInChildren<BaseSnapScript<VerticalSnap>>(includeInactive: true);
            var horizontalSnapPoints = GetComponentsInChildren<BaseSnapScript<HorizontalSnap>>(includeInactive: true);
            var slotPoints = GetComponentsInChildren<BaseSlotScript>(includeInactive: true);

            _snapSlotToggle = new SnapSlotToggle(verticalSnapPoints, horizontalSnapPoints, slotPoints);

            Arrange = new ArrangeBuildItem(
                transform,
                _arrangeColliders,
                getAvailableVerticalSnaps: () => verticalSnapPoints.SelectMany(x => x.GetAvailableSnaps()).ToArray(),
                getAvailableHorizontalSnaps: () => horizontalSnapPoints.SelectMany(x => x.GetAvailableSnaps()));

            ScrapValue = new ScrapValue(_scrapComponents.Select(
                x => new ComponentQuantity(new Component(x.Component.Identifier), x.Quantity)));
        }
    }
}