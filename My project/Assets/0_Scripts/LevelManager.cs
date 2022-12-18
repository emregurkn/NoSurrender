using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private CollectablePos collectablePos;
    private ClosestObjectManager closestEnemyCalculator;
    public int objectSize;

    private void Start()
    {
        collectablePos = GetComponent<CollectablePos>();
        collectablePos.CollectableRandomPos(objectSize);
    }
}
