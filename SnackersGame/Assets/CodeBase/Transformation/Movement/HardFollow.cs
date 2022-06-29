using System;
using UnityEngine;

namespace CodeBase.Components
{
    public class HardFollow : MonoBehaviour
    {
        [SerializeField] private bool _followX;
        [SerializeField] private bool _followY;
        [SerializeField] private bool _followZ;
        
        private Transform _target;
        
        public void SetTarget(Transform target)
        {
            _target = target;
            transform.position = _target.transform.position;
        }

        private void Update()
        {
            Vector3 newPosition = new Vector3();
            if (_followX)
            {
                newPosition.x = _target.position.x;
            }

            if (_followY)
            {
                newPosition.y = _target.position.y;
            }

            if (_followZ)
            {
                newPosition.z = _target.position.z;
            }

            transform.position = newPosition;
        }
    }
}