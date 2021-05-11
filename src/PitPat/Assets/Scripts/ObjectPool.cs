using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool current;
    private GameObject pooledObject;
    private int initialSize;
    private bool growIfFull;
    private List<GameObject> pooledObjects;

    public ObjectPool(GameObject obj, int poolInitialSize, bool poolGrowIfFull)
    {
        current = this;
        pooledObjects = new List<GameObject>();
        pooledObject = obj;
        initialSize = poolInitialSize;
        growIfFull = poolGrowIfFull;
    }

    private void Start()
    {
        /*pooledObjects = new List<GameObject>();
        current = this;
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }*/
    }

    public void Initialize()
    {
        pooledObjects = new List<GameObject>();
        current = this;
        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (growIfFull)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}
