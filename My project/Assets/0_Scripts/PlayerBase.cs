using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;



[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public abstract class PlayerBase : MonoBehaviour, IMoveable, IForceable, ICollectable, IPlayeableArea
{
    #region Variables
    public enum PlayerControllerType
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
    [SerializeField] private DynamicJoystick joystick = null;
    #endregion

    public virtual void Movement(float movementSpeed)
    {


        switch (playerControllerType)
        {
            case PlayerControllerType.Joystick:
                navMeshAgent.speed = moveSpeed;
                PlayerMovement();
                break;

            case PlayerControllerType.AI:
                AIMovement(ClosestObjectManager.instance.GetClosestEnemy());
                break;
        }


    }

    public void PlayerMovement()
    {
        Vector3 inputVec = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Vector3 setNavmesh = transform.localPosition + inputVec;


        if (!navMeshAgent.enabled)
        {
            return;
        }
        navMeshAgent.SetDestination(setNavmesh);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
        }
    }

    public void AIMovement(Transform player)
    {
        navMeshAgent.SetDestination(player.position);
    }

    public void IncreaseSize(float scaleSize, float animationSpeed)
    {
        this.transform.DOScale(scaleAmount, animSPeed).SetEase(Ease.OutElastic);
    }

    public virtual void Force(GameObject obj)
    {
        if (obj.transform.localScale.magnitude >= transform.localScale.magnitude)
        {
            var force = transform.position - obj.transform.position;
            var forceMagnitude = obj.transform.localScale * 2;
            rigidbody.AddForce(force + forceMagnitude, ForceMode.Impulse);
        }
    }

    public bool CheckPlayableArea()
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
