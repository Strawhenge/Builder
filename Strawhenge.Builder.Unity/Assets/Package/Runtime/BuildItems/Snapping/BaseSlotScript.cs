using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems.Snapping
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public abstract class BaseSlotScript : MonoBehaviour
    {
        [SerializeField] Transform _snapSlotAnchor;

        public Transform SnapSlotAnchor => _snapSlotAnchor == null
            ? transform
            : _snapSlotAnchor;

        internal abstract float? GetSlideLength();

        void Awake()
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.isKinematic = true;

            foreach (var collider in GetComponents<Collider>())
                collider.isTrigger = true;
        }
    }
}