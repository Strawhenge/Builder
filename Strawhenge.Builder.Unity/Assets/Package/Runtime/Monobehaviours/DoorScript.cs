using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    public class DoorScript : MonoBehaviour
    {
        Transform _transform;
        Rigidbody _rigidbody;
        Quaternion _resetRotation;
        Vector3 _resetPosition;

        void Awake()
        {
            _transform = transform;
            _resetRotation = _transform.localRotation;
            _resetPosition = _transform.localPosition;
            _rigidbody = GetComponent<Rigidbody>();
        }

        [ContextMenu("Lock")]
        public void Lock()
        {
            _rigidbody.isKinematic = true;
            _transform.localRotation = _resetRotation;
            _transform.localPosition = _resetPosition;
        }

        [ContextMenu("Unlock")]
        public void Unlock()
        {
            _rigidbody.isKinematic = false;
        }
    }
}