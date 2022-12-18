using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

/// <summary>
///     - Player functions and variables
///
/// Takes care of:
///     - manages the player behaviour and sets the variables
///     - basically same as the ai manager because inherited
/// <summary>

public class PlayerManager : PlayerBase
{
    [SerializeField] private float movementSpeed, scaleSize, animationSpeed;
    [SerializeField] private float maxPos, minPos,forceTime;
    private bool start;
    void Start()
    {
        maxMove = maxPos;
        minMove = minPos;
        
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        base.CheckPlayableArea(); 
        isPlayeable = base.CheckPlayableArea(); 

        if (isPlayeable)
        {
            Movement(movementSpeed); 
        }
        else if (!isPlayeable)
        {
            ClosestObjectManager.instance.objects.Remove(transform);
            navMeshAgent.enabled = false;
            gameObject.SetActive(false);
        }
    }

    public override void Movement(float movementSpeed)
    {
        
        moveSpeed = movementSpeed;
        base.Movement(moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            scaleAmount = scaleSize;
            animSPeed = animationSpeed;
            base.IncreaseSize(scaleSize, animationSpeed);
            scaleSize += 0.2f;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            base.Force(other.gameObject);
        }
    }
}
