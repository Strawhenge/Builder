using Strawhenge.Common.Unity.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    public class TriggerCollisionTrackerScript : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidBody;
        [SerializeField] Collider _collider;

        readonly List<Collider> _collidingWith = new();

        public IEnumerable<TScript> GetCollidingWith<TScript>() where TScript : MonoBehaviour
        {
            foreach (var collider in _collidingWith)
            {
                if (collider.TryGetComponent<TScript>(out var script))
                    yield return script;
            }
        }

        void Awake()
        {
            ComponentRefHelper.EnsureHierarchyComponent(ref _rigidBody, nameof(_rigidBody), this);
            _rigidBody.isKinematic = true;

            ComponentRefHelper.EnsureHierarchyComponent(ref _collider, nameof(_collider), this);
            _collider.isTrigger = true;
        }

        void OnDisable()
        {
            _collidingWith.Clear();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.root != transform.root)
                _collidingWith.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            if (_collidingWith.Contains(other))
                _collidingWith.Remove(other);
        }
    }
}