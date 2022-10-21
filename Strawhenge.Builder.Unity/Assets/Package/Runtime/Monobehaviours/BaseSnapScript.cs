using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseSnapScript<TSnap> : MonoBehaviour
    {
        readonly List<Collider> _collidingWith = new List<Collider>();

        Transform _root;
        SnapPoint _snapPoint;

        public IEnumerable<TSnap> GetAvailableSnaps()
        {
            foreach (var collider in _collidingWith)
            {
                yield return Map(_snapPoint, collider.transform);
            }
        }

        protected abstract TSnap Map(SnapPoint snapPoint, Transform snapSlot);

        protected virtual void AfterAwake()
        {
        }

        void Awake()
        {
            var t = transform;
            _root = t.root;
            _snapPoint = new SnapPoint(t);

            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;

            var collider = GetComponent<CapsuleCollider>();
            collider.isTrigger = true;

            AfterAwake();
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