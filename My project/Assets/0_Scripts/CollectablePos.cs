using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collectable variables and functionalities
///
/// Takes care of:
///     - keeping the variables and functionalities of collectables
/// <summary>

public class CollectablePos : MonoBehaviour
{
    
    private ObjectPool objectPool;
    
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    public void CollectableRandomPos(int collectabelSize) //Sets the random pos for collectables at the beginning of the game
    {
        for (int i = 0; i < collectabelSize; i++)
        {
            var position = new Vector3(Random.Range(-8.60f, 9), 0.52f, Random.Range(-8.5f, 8));
            GameObject obj = objectPool.GetPooledObject("Collectable"); //Get the objects from object pool.
            obj.transform.position = position;
        }

    }
}
