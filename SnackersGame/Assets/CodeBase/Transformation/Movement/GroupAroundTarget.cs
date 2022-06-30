using CodeBase.Transformation.Jump;
using UnityEngine;

namespace CodeBase.Transformation.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    
    public class GroupAroundTarget : MonoBehaviour
    {
        private Transform _target;
        private Rigidbody _rigidBody;
        private PhysicsJump _jump;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _jump = GetComponent<PhysicsJump>();
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 targetPosition = _target.position;

                if (_jump.isGrounding)
                {
                    targetPosition.y -= 100;
                }
                else if (transform.position.y > _target.position.y)
                {
                    _rigidBody.AddForce(Vector3.down * 3, ForceMode.VelocityChange);
                }

                Vector3 destination = targetPosition - transform.position;
                _rigidBody.AddForce(destination,  ForceMode.VelocityChange);
            }
        }

        public void SetTarget(Transform target) 
            => _target = target;
    }
}