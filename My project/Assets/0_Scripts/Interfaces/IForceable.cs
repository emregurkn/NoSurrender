using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IForceable 
{
    Vector3 forceAmount { get; set; }
    void Force(float forceAmount);
}
