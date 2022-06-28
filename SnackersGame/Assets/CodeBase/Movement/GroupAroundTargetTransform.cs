using System;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class GroupAroundTargetTransform : MonoBehaviour
    {
        private Transform _target;
        private Rigidbody _rigidBody;
        
        private void Awake() 
            => _rigidBody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            if (_target != null)
            {
                Vector3 destination = _target.position - transform.position;
                _rigidBody.AddForce(destination, ForceMode.VelocityChange);
            }
        }

        public void SetTarget(Transform target) 
            => _target = target;
    }
}