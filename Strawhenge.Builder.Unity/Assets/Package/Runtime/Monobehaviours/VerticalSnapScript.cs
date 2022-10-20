using Strawhenge.Builder.Unity.BuildItems.Snapping;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class VerticalSnapScript : MonoBehaviour
    {
        Transform _root;
        SnapPoint _snapPoint;
        List<Collider> _collidingWith;

        public IEnumerable<VerticalSnap> GetAvailableSnaps()
        {
            return _collidingWith
                .Select(x => new VerticalSnap(_snapPoint, x.transform))
                .ToArray();
        }

        void Awake()
        {
            _root = transform.root;

            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;

            var collider = GetComponent<CapsuleCollider>();
            collider.isTrigger = true;
        }

        void Start()
        {
            _snapPoint = new SnapPoint(transform);
            _collidingWith = new List<Collider>();
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