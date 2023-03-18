using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MechanicBaseState : BaseState
{
    protected MechanicStateHandler MechanicStateHandler => _stateHandler as MechanicStateHandler;
}
