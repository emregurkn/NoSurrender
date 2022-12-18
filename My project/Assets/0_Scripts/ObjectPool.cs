using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object pool variables and functionalities
///
/// Takes care of:
///     - keeping the variables and functionalities of object pool design pattern
///   
/// <summary>

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool // Create a class that holds the variables for every pool.
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    public Dictionary<string, Queue<GameObject>> poolDictionary; //Create a disctionary and attach queue and tag, so we can call pools with tags.
    public List<Pool> pools; //Add pool class to list so we can increase pool size with variables.

    void Awake()//Instantiate objects that we are going to use at awake.
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>(); 

        foreach (Pool pool in pools) //For every pool create a queue that holds the objects
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj); //Add to queue
            }

            poolDictionary.Add(pool.tag, objectPool); //Add queue to dictionary.
        }
    }


    public GameObject GetPooledObject(string tag) //Call the object from object pool with tag.
    {
        if (!poolDictionary.ContainsKey(tag)) //Null check 
        {
            Debug.Log("Pool does not exist");
            return null;
        }

        GameObject objectToUse = poolDictionary[tag].Dequeue();//Get the object from queue
        objectToUse.SetActive(true); 
        
        poolDictionary[tag].Enqueue(objectToUse);//Put it back
        return objectToUse;//Get the object to where function called

    }
}
