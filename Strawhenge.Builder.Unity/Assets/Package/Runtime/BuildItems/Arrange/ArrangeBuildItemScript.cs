using Strawhenge.Common.Unity;
using Strawhenge.Common.Unity.Helpers;
using UnityEngine;

namespace Strawhenge.Builder.Unity.BuildItems
{
    public class ArrangeBuildItemScript : MonoBehaviour
    {
        Rigidbody _rigidbody;
        Vector3 _velocity;
        float _turnAmount;

        public void Move(Vector3 velocity)
        {
            _velocity = velocity;
        }

        public void Turn(float amount)
        {
            _turnAmount = amount;
        }

        void Awake()
        {
            SanitizeRotation(transform);

            _rigidbody = this.GetOrAddComponent<Rigidbody>();
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = false;
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }

        void OnDestroy()
        {
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
            _rigidbody.isKinematic = true;
        }

        void FixedUpdate()
        {
            if (Mathf.Abs(_turnAmount) > 0.01f)
            {
                _rigidbody.constraints = RigidbodyHelper.FreezeAllButRotationY;
                _rigidbody.angularVelocity = Vector3.up * _turnAmount;
                _turnAmount = 0;
                return;
            }

            if (_velocity.magnitude > 0.01f)
            {
                _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                _rigidbody.velocity = _velocity;
                _velocity = Vector3.zero;
                return;
            }

            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        static void SanitizeRotation(Transform transform)
        {
            transform.rotation = Quaternion.Euler(
                new Vector3(0, transform.rotation.eulerAngles.y, 0));
        }
    }
}