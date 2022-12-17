using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    CollectablePos collectablePos;

    void Awake()
    {
        collectablePos = CollectablePos.instance;
    }
    void Start()
    {
        collectablePos.CollectableRandomPos();
    }
}
