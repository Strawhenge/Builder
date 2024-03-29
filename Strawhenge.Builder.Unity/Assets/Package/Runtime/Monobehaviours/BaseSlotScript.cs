using UnityEngine;

namespace Strawhenge.Builder.Unity
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public abstract class BaseSlotScript : MonoBehaviour
    {
        [SerializeField] Transform _snapSlotAnchor;

        public Transform SnapSlotAnchor => _snapSlotAnchor == null
            ? transform
            : _snapSlotAnchor;

        protected Transform Transform;

        internal abstract float? GetSlideLength();

        void Awake()
        {
            Transform = transform;

            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            foreach (var collider in GetComponents<Collider>())
                collider.isTrigger = true;
        }
    }
}