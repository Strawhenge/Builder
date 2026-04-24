using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping.Triggers
{
    public class TriggerCollisionTrackerScript : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidBody;
        [SerializeField] Collider _collider;

        CollisionTracker _tracker;

        internal CollisionTracker Tracker => _tracker ??= new CollisionTracker(transform);

        void Awake()
        {
            ComponentRefHelper.EnsureHierarchyComponent(ref _rigidBody, nameof(_rigidBody), this);
            _rigidBody.isKinematic = true;

            ComponentRefHelper.EnsureHierarchyComponent(ref _collider, nameof(_collider), this);
            _collider.isTrigger = true;
        }

        void OnDisable()
        {
            Tracker.Clear();
        }

        void OnTriggerEnter(Collider other)
        {
            Tracker.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            Tracker.Remove(other);
        }
    }
}