using Strawhenge.Builder.Unity.BuildItems.Snapping.Triggers;
using Strawhenge.Common.Unity.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class HorizontalSnapScript : MonoBehaviour
    {
        [SerializeField] Transform _snapPointAnchor;
        [SerializeField] TriggerCollisionTrackerScript _triggerCollisionTracker;

        HorizontalSnapContainer _container;

        internal HorizontalSnapContainer Container => _container ??= CreateContainer();

        HorizontalSnapContainer CreateContainer()
        {
            var snapPoint = _snapPointAnchor != null
                ? new SnapPoint(_snapPointAnchor)
                : new SnapPoint(transform);

            ComponentRefHelper
                .EnsureHierarchyComponent(ref _triggerCollisionTracker, nameof(_triggerCollisionTracker), this);

            return new HorizontalSnapContainer(
                snapPoint,
                _triggerCollisionTracker.Tracker,
                transform.lossyScale.x);
        }
    }
}