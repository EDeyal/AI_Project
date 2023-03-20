using UnityEngine;

public class LoadFuelState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        if(MechanicStateHandler.MechanicSpaceship.IsFuelLoaded())
        {
            return _stateHandler.DriveState;
        }
        return this;
    }
}
