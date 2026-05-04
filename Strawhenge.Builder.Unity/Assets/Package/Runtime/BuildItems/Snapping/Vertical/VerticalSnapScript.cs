using Strawhenge.Builder.Unity.BuildItems.Snapping.Triggers;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class VerticalSnapScript : MonoBehaviour
    {
        [SerializeField] Transform _snapPointAnchor;
        [SerializeField] TriggerCollisionTrackerScript _triggerCollisionTracker;

        VerticalSnapContainer _container;

        internal VerticalSnapContainer Container => _container ??= CreateContainer();

        VerticalSnapContainer CreateContainer()
        {
            var snapPoint = _snapPointAnchor != null
                ? new SnapPoint(_snapPointAnchor)
                : new SnapPoint(transform);

            ComponentRefHelper
                .EnsureHierarchyComponent(ref _triggerCollisionTracker, nameof(_triggerCollisionTracker), this);

            return new VerticalSnapContainer(
                snapPoint,
                _triggerCollisionTracker.Tracker,
                transform.lossyScale.y);
        }
    }
}