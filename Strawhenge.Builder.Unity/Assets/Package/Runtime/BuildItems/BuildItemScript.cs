using Strawhenge.Builder.Unity.BuildItems.Arrange;
using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Builder.Unity.Components;
using Strawhenge.Common;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class BuildItemScript : MonoBehaviour
    {
        [SerializeField] SerializableComponentQuantity[] _scrapComponents;
        [SerializeField] Collider[] _arrangeColliders;

        ArrangeBuildItem _arrange;
        ScrapValue _scrapValue;
        SnapSlotToggle _snapSlotToggle;
        BaseSnapScript<VerticalSnap>[] _verticalSnapPoints;
        BaseSnapScript<HorizontalSnap>[] _horizontalSnapPoints;
        BaseSlotScript[] _slotPoints;

        internal IArrangeBuildItem Arrange => _arrange ??= CreateArrangeBuildItem();

        internal ScrapValue ScrapValue => _scrapValue ??= CreateScrapValue();

        internal void SetArranging()
        {
            _snapSlotToggle ??= CreateSnapSlotToggle();
            _snapSlotToggle.Snaps();
        }

        internal void SetPlaced()
        {
            _snapSlotToggle ??= CreateSnapSlotToggle();
            _snapSlotToggle.Slots();
        }

        void Awake()
        {
            _arrange ??= CreateArrangeBuildItem();
            _scrapValue ??= CreateScrapValue();
            _snapSlotToggle ??= CreateSnapSlotToggle();
        }

        ArrangeBuildItem CreateArrangeBuildItem()
        {
            _verticalSnapPoints ??= GetComponentsInChildren<BaseSnapScript<VerticalSnap>>(includeInactive: true);
            _horizontalSnapPoints ??= GetComponentsInChildren<BaseSnapScript<HorizontalSnap>>(includeInactive: true);

            return new ArrangeBuildItem(
                transform,
                _arrangeColliders.ExcludeNull().ToArray(),
                getAvailableVerticalSnaps: () => _verticalSnapPoints.SelectMany(x => x.GetAvailableSnaps()).ToArray(),
                getAvailableHorizontalSnaps: () => _horizontalSnapPoints.SelectMany(x => x.GetAvailableSnaps()));
        }

        SnapSlotToggle CreateSnapSlotToggle()
        {
            _verticalSnapPoints ??= GetComponentsInChildren<BaseSnapScript<VerticalSnap>>(includeInactive: true);
            _horizontalSnapPoints ??= GetComponentsInChildren<BaseSnapScript<HorizontalSnap>>(includeInactive: true);
            _slotPoints ??= GetComponentsInChildren<BaseSlotScript>(includeInactive: true);

            return new SnapSlotToggle(_verticalSnapPoints, _horizontalSnapPoints, _slotPoints);
        }

        ScrapValue CreateScrapValue()
        {
            return new ScrapValue(_scrapComponents.ExcludeNull().Select(x =>
                new ComponentQuantity(
                    new Component(x.Component.Identifier), x.Quantity)));
        }
    }
}