using SnapPoint = Strawhenge.Builder.Unity.BuildItems.Snapping.SnapPoint;
using Strawhenge.Common.Ranges;
using Strawhenge.Common.Unity.Helpers;
using System.Collections.Generic;
using UnityEngine;
using VerticalSnap = Strawhenge.Builder.Unity.BuildItems.Snapping.VerticalSnap;

namespace Strawhenge.Builder.Unity.BuildItems.NewSnapping
{
    public class VerticalSnapScript : MonoBehaviour
    {
        [SerializeField] Transform _snapPointAnchor;
        [SerializeField] TriggerCollisionTrackerScript _triggerCollisionTracker;

        SnapPoint _snapPoint;

        internal IEnumerable<VerticalSnap> GetAvailableSnaps()
        {
            // TODO Maybe change initialization?
            _snapPoint ??= CreateSnapPoint();
            ComponentRefHelper
                .EnsureHierarchyComponent(ref _triggerCollisionTracker, nameof(_triggerCollisionTracker), this);

            foreach (var collider in _triggerCollisionTracker.CollidingWith)
            {
                if (collider.TryGetComponent<VerticalSlotScript>(out var snapSlotScript))
                    yield return Map(_snapPoint, snapSlotScript.Slot);
            }
        }

        SnapPoint CreateSnapPoint()
        {
            return _snapPointAnchor != null
                ? new SnapPoint(_snapPointAnchor)
                : new SnapPoint(transform);
        }

        VerticalSnap Map(SnapPoint snapPoint, VerticalSlot snapSlot) =>
            new(
                snapPoint,
                snapSlot.Anchor,
                snapSlot.CanRotate,
                snapSlot.PresetAngles,
                FloatRange.Zero); // TODO SlideRangeHelper.GetRange(this, snapSlotScript)
    }
}

