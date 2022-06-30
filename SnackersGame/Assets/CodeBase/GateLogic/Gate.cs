using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Spawn;
using CodeBase.Transformation.Movement;
using UnityEngine;

namespace CodeBase.GateLogic
{
    public class Gate : MonoBehaviour
    {
        public event Action<Gate> OnUnitEnter;
        public GateType GateType => _type;
        public int Value => _value;
        public MathOperation Operation => _operation;

        [SerializeField] private GateType _type;
        [SerializeField] private int _value;
        [SerializeField] private MathOperation _operation;
        
        private ISpawnService _spawnService;

        private void Awake()
        {
            _spawnService = ServiceLocator.Container.Single<ISpawnService>();
        }

        private void OnDisable() 
            => GetComponent<BoxCollider>().enabled = false;

        private void OnTriggerEnter(Collider other)
        {
            Movable movable = other.GetComponent<Movable>();
            if (movable != null)
            {
                OnUnitEnter?.Invoke(this);
                _spawnService.Player.ChangeUnitsCount(_operation, _value);
                Hide();
            }
        }

        private void Hide()
            => gameObject.SetActive(false);
    }
}