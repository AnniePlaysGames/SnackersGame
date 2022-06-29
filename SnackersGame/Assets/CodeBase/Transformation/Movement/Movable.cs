using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(PhysicsMovement))]
    public class Movable : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement _movement;
        [SerializeField] private bool _freezeRotationDefault;
        private IInputService _inputService;
        private Rigidbody _rigidBody;
        private GroupAroundTarget _grouping; 

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Single<IInputService>();
            _movement = GetComponent<PhysicsMovement>();
            _rigidBody = GetComponent<Rigidbody>();
            _grouping = GetComponent<GroupAroundTarget>();
        }

        private void OnEnable()
        {
            _rigidBody.freezeRotation = _freezeRotationDefault;
            _rigidBody.useGravity = true;

            if (_grouping)
            {
                _grouping.enabled = true;
            }
        }

        private void OnDisable()
        {
            _rigidBody.freezeRotation = true;
            _rigidBody.useGravity = false;
            
            if (_grouping)
            {
                _grouping.enabled = false;
            }
        }

        private void FixedUpdate() 
            => _movement.Move(_inputService.HorizontalStickPosition);
    }
}