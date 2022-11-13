using Strawhenge.Builder.Unity.BuildItems.Snapping;
using Strawhenge.Common.Ranges;
using System.Collections.Generic;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    public abstract class BaseSnapScript<TSnap> : MonoBehaviour
    {
        public abstract IEnumerable<TSnap> GetAvailableSnaps();
    }

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseSnapScript<TSnap, TSnapSlotScript> : BaseSnapScript<TSnap>
        where TSnapSlotScript : MonoBehaviour
    {
        readonly List<Collider> _collidingWith = new List<Collider>();

        [SerializeField] Transform _snapPointAnchor;

        Transform _root;
        SnapPoint _snapPoint;

        protected Transform Transform;

        public override IEnumerable<TSnap> GetAvailableSnaps()
        {
            foreach (var collider in _collidingWith)
            {
                if (collider.TryGetComponent<TSnapSlotScript>(out var snapSlotScript))
                    yield return Map(_snapPoint, snapSlotScript);
            }
        }

        internal abstract float? GetSlideLength();
        
        protected abstract TSnap Map(SnapPoint snapPoint, TSnapSlotScript snapSlotScript);

        void Awake()
        {
            Transform = transform;
            _root = Transform.root;

            _snapPoint = _snapPointAnchor == null
                ? new SnapPoint(Transform)
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