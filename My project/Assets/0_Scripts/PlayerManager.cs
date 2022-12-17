using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class PlayerManager : PlayerBase
{
    [SerializeField] private float movementSpeed, scaleSize, animationSpeed;
    [SerializeField] private Vector3 forceValue;
    new Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Movement(movementSpeed);
    }

    public override void Movement(float movementSpeed)
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveSpeed = movementSpeed;
        base.Movement(moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            scaleAmount = scaleSize;
            animSPeed = animationSpeed;
            IncreaseSize(scaleSize, animationSpeed);
            scaleSize += 0.2f;
        }

        if (other.gameObject.CompareTag("AI"))
        {
            forceAmount = forceValue;
            Force(rigidbody,forceValue);
        }
    }
}
