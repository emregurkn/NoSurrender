using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePos : MonoBehaviour
{
    private ObjectPool objectPool;
    
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void CollectableRandomPos(int collectabelSize)
    {
        for (int i = 0; i < collectabelSize; i++)
        {
            var position = new Vector3(Random.Range(-8.60f, 9), 0.52f, Random.Range(-8.5f, 8));
            GameObject obj = objectPool.GetPooledObject("Collectable");
            obj.transform.position = position;
        }

    }
}
