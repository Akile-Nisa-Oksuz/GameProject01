using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXPooler : MonoBehaviour
{
    public static SoundFXPooler curret;
    public GameObject pooledObject;
    public int pooledAmount = 10;
    public bool willGrow = true;
    // Start is called before the first frame update


    public List<GameObject> pooledObjects;

    void Awake()
    {
        curret = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetpooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        if (willGrow)
        {
            GameObject obj = Instantiate(pooledObject);
            pooledObjects.Add(obj);
            return obj;
        }
        return null;
    }
}

