using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseDriveState : BaseState
{
    public override void ExitState()
    {
        base.ExitState();
        //_spaceship.ReachedDestination = false;
    }
}
