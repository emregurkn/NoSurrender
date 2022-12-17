using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody),typeof(NavMeshAgent))]
public abstract class PlayerBase : MonoBehaviour,IMoveable,IForceable,ICollectable
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

    public PlayerControllerType playerControllerType;
    #endregion

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public virtual void Force(float forceAmount)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Movement(float moveSpeed)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Collect()
    {
        throw new System.NotImplementedException();
    }
}
