using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
   float scaleAmount { get; set; }
   float animSPeed { get; set; }
   void IncreaseSize(float scaleAmount,float animSpeed);
}
