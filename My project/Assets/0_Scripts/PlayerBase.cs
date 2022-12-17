using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;



[RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
public abstract class PlayerBase : MonoBehaviour, IMoveable, IForceable, ICollectable
{
    #region Variables
    public enum PlayerControllerType
    {
        Joystick,
        AI
    }

    public float moveSpeed { get; set; }
    public NavMeshAgent navMeshAgent { get; set; }
    public Vector3 forceAmount { get; set; }
    public float scaleAmount { get; set; }
    public float animSPeed { get; set; }

    public PlayerControllerType playerControllerType;
    [SerializeField] private DynamicJoystick joystick = null;
    #endregion

    public virtual void Force(Rigidbody rigidbody,Vector3 forceAmount)
    {
        navMeshAgent.enabled = false;
        rigidbody.AddForce(forceAmount,ForceMode.Impulse);
        navMeshAgent.enabled = true;
    }

    public virtual void Movement(float movementSpeed)
    {
        switch (playerControllerType)
        {
            case PlayerControllerType.Joystick:
                navMeshAgent.speed = moveSpeed;
                PlayerMovement();
                break;

            case PlayerControllerType.AI:
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

    public void AIMovement()
    {

    }

    public void IncreaseSize(float scaleSize, float animationSpeed)
    {
        this.transform.DOScale(scaleAmount, animSPeed).SetEase(Ease.OutElastic);
    }
}
