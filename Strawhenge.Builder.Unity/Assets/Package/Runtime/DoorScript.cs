using UnityEngine;

namespace Strawhenge.Builder.Unity.Monobehaviours
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(HingeJoint))]
    public class DoorScript : MonoBehaviour
    {
        Transform _transform;
        Rigidbody _rigidbody;
        HingeJoint _hinge;
        
        Quaternion _resetRotation;
        Vector3 _resetPosition;
        Vector3 _resetHingeAnchorPosition;

        void Awake()
        {
            _transform = transform;
            _resetRotation = _transform.localRotation;
            _resetPosition = _transform.localPosition;

            _rigidbody = GetComponent<Rigidbody>();

            _hinge = GetComponent<HingeJoint>();
            _resetHingeAnchorPosition = _hinge.connectedAnchor;
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
            _hinge.connectedAnchor = _resetHingeAnchorPosition;
            _rigidbody.isKinematic = false;
        }
    }
}