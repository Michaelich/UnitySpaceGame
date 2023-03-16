using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public static ObjectPool SharedInstance2;
    public static ObjectPool SharedInstance3;
    public List<GameObject> pooledObjects;
    public List<GameObject> pooledObjects2;
    public List<GameObject> pooledObjects3;
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject objectToPool2;
    public int amountToPool2;
    public GameObject objectToPool3;
    public int amountToPool3;

    public GameObject GetPooledObject()
    {
        for (int i =0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            return pooledObjects[i];
        }
        return null;
    }

    public GameObject GetPooledObject2()
    {
        for (int i =0; i < amountToPool2; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            return pooledObjects2[i];
        }
        return null;
    }

    public GameObject GetPooledObject3()
    {
        for (int i =0; i < amountToPool3; i++)
        {
            if (!pooledObjects3[i].activeInHierarchy)
            return pooledObjects3[i];
        }
        return null;
    }


    void Awake()
    {
        SharedInstance = this;
        SharedInstance2 = this;
        SharedInstance3 = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i< amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
        pooledObjects2 = new List<GameObject>();
        GameObject tmp2;
        for (int i = 0; i< amountToPool2; i++)
        {
            tmp2 = Instantiate(objectToPool2);
            tmp2.SetActive(false);
            pooledObjects2.Add(tmp2);
        }
        pooledObjects3 = new List<GameObject>();
        GameObject tmp3;
        for (int i = 0; i< amountToPool3; i++)
        {
            tmp3 = Instantiate(objectToPool3);
            tmp3.SetActive(false);
            pooledObjects3.Add(tmp3);
        }
    }


}
