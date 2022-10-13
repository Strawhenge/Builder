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
        SnapPoint snapPoint;
        List<Collider> collidingWith;

        public IEnumerable<VerticalSnap> GetAvailableSnaps()
        {
            return collidingWith
                .Select(x => new VerticalSnap(snapPoint, x.transform))
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
            snapPoint = new SnapPoint(transform);
            collidingWith = new List<Collider>();
        }

        void OnTriggerEnter(Collider other)
        {
            collidingWith.Add(other);
        }

        void OnTriggerExit(Collider other)
        {
            collidingWith.Remove(other);
        }
    }
}
