using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler EnemyObjectPooler;

    public GameObject EnemyPooledObject;
    public int EnemyPooledAmount;
    public bool willGrowEnemies;

    public List<GameObject> _EnemyPooledObjects;

    private void Start()
    {
        EnemyObjectPooler = this;
        _EnemyPooledObjects = new List<GameObject>();

        for (int i = 0; i < EnemyPooledAmount; i++)
        {
            GameObject obj = Instantiate(EnemyPooledObject);
            obj.SetActive(false);
            _EnemyPooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {

        for (int i = 0; i < _EnemyPooledObjects.Count; i++)
        {
            if (!_EnemyPooledObjects[i].activeInHierarchy)
            {
                return _EnemyPooledObjects[i];
            }

        }

        if (willGrowEnemies)
        {
            GameObject obj = Instantiate(EnemyPooledObject);
            _EnemyPooledObjects.Add(obj);
            return obj;
        }

        return null;
    }



}
