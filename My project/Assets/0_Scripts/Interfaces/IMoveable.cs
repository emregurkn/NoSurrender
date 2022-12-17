using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IMoveable
{
    float moveSpeed { get; set; }
    NavMeshAgent navMeshAgent { get; set;}
    void Movement(float moveSpeed);
}
