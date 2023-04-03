using UnityEngine;

public class LoadFuelTankState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        if(MechanicStateHandler.MechanicSpaceship.IsFuelLoaded())
        {
            Debug.Log("Mechanic is going to drive state");
            return _stateHandler.DriveState;
        }
        return this;
    }
}
