using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.Factories;
using UnityEngine;

namespace CodeBase.Components
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int _amountToPool;
        private List<GameObject> _pooledObjects;

        public void InitPool()
        {
            IUnitFactory unitFactory = ServiceLocator.Container.Single<IUnitFactory>();
            _pooledObjects = new List<GameObject>();
            for (int i = 0; i < _amountToPool; i++)
            {
                GameObject pooledObject = unitFactory.CreateUnit();
                pooledObject.SetActive(false);
                _pooledObjects.Add(pooledObject);
            }
        }

        public GameObject GetPooledObject()
        {
            for(int i = 0; i < _amountToPool; i++)
            {
                if(_pooledObjects[i].activeInHierarchy == false)
                {
                    return _pooledObjects[i];
                }
            }
            return null;
        }
    }
}