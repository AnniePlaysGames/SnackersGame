using System;
using CodeBase.Components.GateLogic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;

namespace CodeBase.Components
{
    public class Player : MonoBehaviour
    {
        private IInputService _inputService;
        private PhysicsMovement _movement;
        private int _unitsCount = 1;
        
        public event Action OnUnitsOver;
        public Transform LookPoint { get; private set; }

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Single<IInputService>();
            _movement = GetComponent<PhysicsMovement>();
            LookPoint = GetComponentInChildren<CameraLookPoint>().transform;
        }

        private void Update()
        {
            _movement.Move(_inputService.HorizontalStickPosition);
        }

        public void ChangeUnitsCount(MathOperation operation, int value)
        {
            ApplyOperation(operation, value);
            CheckForUnitsOver();
            Debug.Log("Units Count:" + _unitsCount);
        }

        private void ApplyOperation(MathOperation operation, int value)
        {
            switch (operation)
            {
                case MathOperation.Addition:
                    _unitsCount += value;
                    break;
                case MathOperation.Subtraction:
                    _unitsCount -= value;
                    break;
                case MathOperation.Multiplication:
                    _unitsCount *= value;
                    break;
                case MathOperation.Division:
                    _unitsCount /= value;
                    break;
            }
        }
        private void CheckForUnitsOver()
        {
            if (_unitsCount <= 0)
            {
                OnUnitsOver?.Invoke();
            }
        }
    }
}