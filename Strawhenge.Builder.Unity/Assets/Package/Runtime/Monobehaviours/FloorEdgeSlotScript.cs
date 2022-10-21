using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class FloorEdgeSlotScript : MonoBehaviour
    {
        [SerializeField] Transform _snapSlotAnchor;
        [SerializeField] bool _canFlip;

        public Transform SnapSlotAnchor => _snapSlotAnchor == null
            ? transform
            : _snapSlotAnchor;

        public bool CanFlip => _canFlip;

        void Awake()
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            foreach (var collider in GetComponents<Collider>())
                collider.isTrigger = true;
        }
    }
}