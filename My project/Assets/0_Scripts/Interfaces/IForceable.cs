using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IForceable 
{
    Rigidbody rigidbody { get; set; }
    void Force(GameObject obj);
}
