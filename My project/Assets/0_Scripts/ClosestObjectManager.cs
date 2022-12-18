using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     - Object dist calculator
///
/// Takes care of:
///     - Calculates the objects dist for ai movement and return it back.
/// <summary>

public class ClosestObjectManager : MonoBehaviour
{
    private ObjectPool objectPool;
    private TimeCounter timeCounter;
    public List<Transform> objects; //Player and ai list to calculate dist and check the winner.
    public Button resButton; 


    #region Singleton //Singleton design pattern
    public static ClosestObjectManager instance { get; private set; }
    private void OnEnable()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
        timeCounter = GetComponent<TimeCounter>();
    }

    private void Update()
    {
        if (objects.Count == 1) //If there is one element in list, there is a winner and game is finish.
        {
            resButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public Transform GetClosestEnemy() //Calculate dist of objects.
    {
        Transform bestTarget = null;
        float closestDistSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position; //Take the current pos.

        foreach (Transform target in objects) //Every object in list
        {
            Vector3 directionToTarget = target.position - currentPosition; 
            float dSqrToTarget = directionToTarget.sqrMagnitude; //Calculate the dist with sqrMagnitude because it is much optimize according to distance func.
            if (dSqrToTarget < closestDistSqr)
            {
                closestDistSqr = dSqrToTarget;
                bestTarget = target;
            }
        }

        return bestTarget; //Return closest obj.
    }
}
