using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level variables and functionalities
///
/// Takes care of:
///     - keeping the variables and functionalities of general level
/// <summary>

public class LevelManager : MonoBehaviour
{
    private CollectablePos collectablePos;
    public int objectSize;

    private void Start()
    {
        collectablePos = GetComponent<CollectablePos>();
        collectablePos.CollectableRandomPos(objectSize);
    }
}
