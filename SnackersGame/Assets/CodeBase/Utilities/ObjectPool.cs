using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Components
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private int amountToPool;
        private List<GameObject> _pooledObjects;

        private void Awake()
        {

        }

        private void InitPool(GameObject obj)
        {
            _pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject pooledWeapon =;
                pooledWeapon.SetActive(false);
                _pooledObjects.Add(pooledWeapon);
            }
        }

        public GameObject GetPooledWeapon()
        {
            for(int i = 0; i < amountToPool; i++)
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