using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PoolInfo
{
    public GameObject objectToPool;
    public int poolCount;
    public List<GameObject> pooledObjects = new();
}

public interface IPoolable
{
    //fonction qui reset les stats definit dans les autres scripts implementant l'interface
    void Reset();
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<PoolInfo> objToPool; //add weapon on pickup



    private static ObjectPool instance;
    public static ObjectPool GetInstance() => instance;
    int poolIndex;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        foreach (var pool in objToPool)
        {
            for (int i = 0; i < pool.poolCount; i++)
            {
                GameObject item = Instantiate(pool.objectToPool, Vector3.zero, Quaternion.identity, transform); //transform == define qui est le parent
                item.SetActive(false);
                pool.pooledObjects.Add(item);
            }
        }
        
    }

    void addPool(PoolInfo newPool)
    {
        objToPool.Add(newPool);
        for (int i = 0; i < newPool.poolCount; i++)
        {
            GameObject item = Instantiate(newPool.objectToPool, Vector3.zero, Quaternion.identity, transform); //transform == define qui est le parent
            item.SetActive(false);
            newPool.pooledObjects.Add(item);
        }
    }
    public GameObject GetPooledObject(GameObject obj)
    {
        foreach(var pool in objToPool)
        {
            if (pool.objectToPool.ToString() == obj.ToString())
            {
                Debug.Log(obj.GetType());
                poolIndex %= pool.poolCount;
                GameObject p = pool.pooledObjects[poolIndex++];
                p.GetComponent<IPoolable>().Reset();
                return p;
            }
        }
        return null; //test this later
    }




    //take out these vvvvvvvvvvvvvvv when PoolInfo is fully functional
    //[SerializeField] GameObject objectToPool;
    //[SerializeField] int poolCount = 100;

    //List<GameObject> pooledObj = new();
}
