using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterDriverState : BaseDriveState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Driving");
        return this;
    }
}
