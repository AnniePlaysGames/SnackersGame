using System;
using System.Collections.Generic;
using CodeBase.CameraLogic;
using CodeBase.GateLogic;
using CodeBase.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.PlayerLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _initialUnitsCount = 1;
        private List<Unit> _unitList = new List<Unit>();
        private int _unitsCount = 0;
        private float SpawnOffsetCoefficient => Random.Range(-0.2f, 0.2f);

        public Transform LookPoint { get; private set; }
        public event Action OnUnitsOver;
        public ObjectPool ObjectPool { get; set; }

        private void Awake() 
            => LookPoint = GetComponentInChildren<CameraLookPoint>().transform;

        private void Start() 
            => ChangeUnitsCount(MathOperation.Addition, _initialUnitsCount);

        public void ChangeUnitsCount(MathOperation operation, int value)
        {
            int oldCount = _unitsCount;
            ApplyOperation(operation, value);
            int newCount = _unitsCount;
            CheckForUnitsOver();
            UpdateUnits(newCount - oldCount);
        }

        public void DeleteUnit(Unit unit)
        {
            ApplyOperation(MathOperation.Subtraction, 1);
            CheckForUnitsOver();
            unit.Deactivate();
            _unitList.Remove(unit);
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

        private void UpdateUnits(int difference)
        {
            if (difference > 0)
            {
                for (int i = 0; i < difference; i++)
                {
                    GameObject unitObject = ObjectPool.GetPooledObject();
                    unitObject.transform.position = new Vector3(transform.position.x + SpawnOffsetCoefficient, transform.position.y,
                        transform.position.z + SpawnOffsetCoefficient);
                    unitObject.SetActive(true);
                    _unitList.Add(unitObject.GetComponent<Unit>());
                }
            }

            else if (difference < 0)
            {
                int countToDeactivate = Math.Abs(difference);
                for (int i = 0; i < countToDeactivate; i++)
                {
                    Unit unit = _unitList[i];
                    unit.gameObject.SetActive(false);
                    _unitList.Remove(unit);
                }
            }
        }
    } 
}