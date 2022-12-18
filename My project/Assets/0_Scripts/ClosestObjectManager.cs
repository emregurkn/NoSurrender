using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosestObjectManager : MonoBehaviour
{
    private ObjectPool objectPool;
    private TimeCounter timeCounter;
    public List<Transform> objects;
    public Button resButton; 


    #region Singleton
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
        if (objects.Count == 1)
        {
            resButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (Transform target in objects)
        {
            Vector3 directionToTarget = target.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistSqr)
            {
                closestDistSqr = dSqrToTarget;
                bestTarget = target;
            }
        }

        return bestTarget;
    }
}
