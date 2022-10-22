using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseSnapScript<TSnap, TSnapSlotScript> : MonoBehaviour
        where TSnapSlotScript : MonoBehaviour
    {
        readonly List<Collider> _collidingWith = new List<Collider>();

        [SerializeField] Transform _snapPointAnchor;

        Transform _root;
        SnapPoint _snapPoint;

        public IEnumerable<TSnap> GetAvailableSnaps()
        {
            foreach (var collider in _collidingWith)
            {
                if (collider.TryGetComponent<TSnapSlotScript>(out var snapSlotScript))
                    yield return Map(_snapPoint, snapSlotScript);
            }
        }

        protected abstract TSnap Map(SnapPoint snapPoint, TSnapSlotScript snapSlotScript);

        void Awake()
        {
            var t = transform;
            _root = t.root;

            _snapPoint = _snapPointAnchor == null
                ? new SnapPoint(t)
                : new SnapPoint(_snapPointAnchor);

            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;

            var collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.transform.root != _root)
                _collidingWith.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            if (_collidingWith.Contains(other))
                _collidingWith.Remove(other);
        }
    }
}