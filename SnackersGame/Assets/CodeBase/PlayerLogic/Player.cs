using System;
using System.Collections.Generic;
using CodeBase.Components.GateLogic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Input;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Components
{
    public class Player : MonoBehaviour
    {
        private const int InitialUnitsCount = 1;
        private Queue<GameObject> _unitsQueue = new Queue<GameObject>();
        private int _unitsCount = 0;
        private float SpawnOffsetCoefficient => Random.Range(-0.2f, 0.2f);

        public event Action OnUnitsOver;
        public ObjectPool ObjectPool { get; set; }
        public Transform LookPoint { get; private set; }

        private void Awake()
        {
            LookPoint = GetComponentInChildren<CameraLookPoint>().transform;
        }

        private void Start()
        {
            ChangeUnitsCount(MathOperation.Addition, InitialUnitsCount);
        }

        public void ChangeUnitsCount(MathOperation operation, int value)
        {
            int oldCount = _unitsCount;
            ApplyOperation(operation, value);
            int newCount = _unitsCount;
            CheckForUnitsOver();
            UpdateUnits(newCount - oldCount);
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
                    GameObject unit = ObjectPool.GetPooledObject();
                    unit.transform.SetParent(gameObject.transform, false);
                    Vector3 unitPosition = unit.transform.position;
                    unit.transform.position = new Vector3(unitPosition.x + SpawnOffsetCoefficient, unitPosition.y,
                        unitPosition.z + SpawnOffsetCoefficient);
                    unit.SetActive(true);
                    _unitsQueue.Enqueue(unit);
                }
            }

            else if (difference < 0)
            {
                for (int i = 0; i > difference; i--)
                {
                    GameObject unit = _unitsQueue.Dequeue();
                    unit.SetActive(false);
                }
            }
        }
    }
}