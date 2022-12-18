using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

/// <summary>
///     - AI behaviours
///
/// Takes care of:
///     - manages the ai behaviour and sets the variables
/// <summary>

public class AIManager : PlayerBase
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
        base.CheckPlayableArea(); //Checks if it is on the playeable are or not before movement function.
        isPlayeable = base.CheckPlayableArea(); //Sets the bool function to bool variable for if statment

        if (isPlayeable)
        {
            Movement(movementSpeed); //Movement function if it is playeable
        }
        else if (!isPlayeable)
        {
            ClosestObjectManager.instance.objects.Remove(transform); //If it is not on playeable are, it means it is eliminated.
            navMeshAgent.enabled = false; //Enable Navmesh so rigidbody can do its job.
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
            scaleAmount = scaleSize; //We sets the variables.
            animSPeed = animationSpeed;
            base.IncreaseSize(scaleSize, animationSpeed);//Call function that increase size of player and ai
            scaleSize += 0.2f;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            base.Force(other.gameObject); //Add force function
        }
    }
}
