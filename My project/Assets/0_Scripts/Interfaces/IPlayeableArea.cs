using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayeableArea 
{
    float minMove { get; set; }
    float maxMove { get; set; }
    bool isPlayeable { get; set; }

    bool CheckPlayableArea();
    

}
