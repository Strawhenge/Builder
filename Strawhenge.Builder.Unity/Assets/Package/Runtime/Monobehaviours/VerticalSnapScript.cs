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
            _collidingWith.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            _collidingWith.Remove(other);
        }
    }
}