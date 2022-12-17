using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePos : MonoBehaviour
{
    ObjectPool objectPool;
    [SerializeField] private int collectabelSize;
    
    #region Singleton
    public static CollectablePos instance { get; private set; }
    private void OnEnable()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        objectPool = ObjectPool.instance;
        CollectableRandomPos();
    }

    public void CollectableRandomPos()
    {
        for (int i = 0; i < collectabelSize; i++)
        {
            var position = new Vector3(Random.Range(-8.60f, 9), 0.52f, Random.Range(-8.5f, 8));
            GameObject obj = objectPool.GetPooledObject("Collectable", position);
        }

    }
}
