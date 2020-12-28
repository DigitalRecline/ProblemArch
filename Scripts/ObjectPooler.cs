using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler PalyerProjectilePooler;

    public GameObject PooledObject;
    public int PooledAmount;
    public bool willGrow;

    public List<GameObject> _pooledObjects;

    private void Start()
    {
        PalyerProjectilePooler = this;
        _pooledObjects = new List<GameObject>();
        
        for (int i = 0; i < PooledAmount; i++)
        {
            GameObject obj = Instantiate(PooledObject);
            obj.SetActive(false);
            _pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < _pooledObjects.Count; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }

        }

        if (willGrow)
        {
            GameObject obj = Instantiate(PooledObject);
            _pooledObjects.Add(obj);
            return obj;
        }

        return null;
    }



}
