using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

/// <summary>
/// All the ai and player variables,functions and interfaces
/// 
/// Takes care of:
///     - keeping the variables and functionalities of ai and player
///     - Every calculation is here and sended to the managers
///     - In order to be solid in general, every function and variable 
///       is taken from interfaces. Here, the calculation is performed and sent to the manager function.
/// <summary>

[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public abstract class PlayerBase : MonoBehaviour, IMoveable, IForceable, ICollectable, IPlayeableArea //An abstract class for ai and player
{
    #region Variables
    public enum PlayerControllerType //Deside it is an ai or player so the behavior changes according to this
    {
        Joystick,
        AI
    }

    public float moveSpeed { get; set; }
    public NavMeshAgent navMeshAgent { get; set; }
    public float scaleAmount { get; set; }
    public float animSPeed { get; set; }
    public new Rigidbody rigidbody { get; set; }
    public float minMove { get; set; }
    public float maxMove { get; set; }
    public bool isPlayeable { get; set; }

    public PlayerControllerType playerControllerType;
    [SerializeField] private DynamicJoystick joystick = null; //Joyistic for player movement
    #endregion

    public virtual void Movement(float movementSpeed) //According to enum type call the necessary function.
    {
        switch (playerControllerType) 
        {
            case PlayerControllerType.Joystick:
                navMeshAgent.speed = moveSpeed;
                PlayerMovement();
                break;

            case PlayerControllerType.AI:
                AIMovement(ClosestObjectManager.instance.GetClosestEnemy());//Take the closest enemy and set the destination to it.
                break;
        }
    }

    public void PlayerMovement() //PLayer movement
    {
        Vector3 inputVec = new Vector3(joystick.Horizontal, 0, joystick.Vertical);//Take joystick input
        Vector3 setNavmesh = transform.localPosition + inputVec; //Set it


        if (!navMeshAgent.enabled)// Null check
        {
            return;
        }
        navMeshAgent.SetDestination(setNavmesh); //Send to the player
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
        }
    }

    public void AIMovement(Transform player) //Set the ai movement
    {
        navMeshAgent.SetDestination(player.position); 
    }

    public void IncreaseSize(float scaleSize, float animationSpeed)//When pick the collactable increase size with dotween animations.
    {
        this.transform.DOScale(scaleAmount, animSPeed).SetEase(Ease.OutElastic);
    }

    public virtual void Force(GameObject obj) //When we get git from others, get force according to their scale.
    {
        if (obj.transform.localScale.magnitude >= transform.localScale.magnitude) //If you have less scale you can not force others
        {
            var force = transform.position - obj.transform.position;
            var forceMagnitude = obj.transform.localScale * 2;
            rigidbody.AddForce(force + forceMagnitude, ForceMode.Impulse);
        }
    }

    public bool CheckPlayableArea() //Check playeable area and return a bool for movement
    {
        if (transform.position.x < maxMove && transform.position.x > minMove && transform.position.z < maxMove && transform.position.z > minMove)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
