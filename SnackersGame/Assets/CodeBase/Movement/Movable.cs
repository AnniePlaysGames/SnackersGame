using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Components
{
    [RequireComponent(typeof(PhysicsMovement))]
    public class Movable : MonoBehaviour
    {
        [SerializeField] private PhysicsMovement _movement;
        private IInputService _inputService;

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Single<IInputService>();
            _movement = GetComponent<PhysicsMovement>();
        }

        private void FixedUpdate() 
            => _movement.Move(_inputService.HorizontalStickPosition);
    }
}