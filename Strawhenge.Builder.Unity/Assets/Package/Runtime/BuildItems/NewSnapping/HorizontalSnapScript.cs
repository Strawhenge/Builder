using SnapPoint = Strawhenge.Builder.Unity.BuildItems.Snapping.SnapPoint;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Helpers;
using System.Collections.Generic;
using UnityEngine;
using HorizontalSnap = Strawhenge.Builder.Unity.BuildItems.Snapping.HorizontalSnap;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    public class HorizontalSnapScript : MonoBehaviour
    {
        [SerializeField] Transform _snapPointAnchor;
        [SerializeField] TriggerCollisionTrackerScript _triggerCollisionTracker;

        SnapPoint _snapPoint;

        internal IEnumerable<HorizontalSnap> GetAvailableSnaps()
        {
            // TODO Maybe change initialization?
            _snapPoint ??= CreateSnapPoint();
            ComponentRefHelper
                .EnsureHierarchyComponent(ref _triggerCollisionTracker, nameof(_triggerCollisionTracker), this);

            foreach (var collider in _triggerCollisionTracker.CollidingWith)
            {
                if (collider.TryGetComponent<HorizontalSlotScript>(out var snapSlotScript))
                    yield return Map(_snapPoint, snapSlotScript.Slot);
            }
        }

        SnapPoint CreateSnapPoint()
        {
            return _snapPointAnchor != null
                ? new SnapPoint(_snapPointAnchor)
                : new SnapPoint(transform);
        }

        HorizontalSnap Map(SnapPoint snapPoint, HorizontalSlot snapSlot) =>
            new(
                snapPoint,
                snapSlot.Anchor,
                snapSlot.TiltRange,
                FloatRange.Zero, // TODO SlideRangeHelper.GetRange(this, snapSlotScript),
                snapSlot.CanFlip);
    }
}