using UnityEngine;

public class MechanicRepairState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Loading Fuel");
        if (MechanicStateHandler.MechanicSpaceship.IsSpaceshipRepaired())
        {
            //spaceship is repaired
            return _stateHandler.DriveState;
        }
        else
        {
            if (MechanicStateHandler.MechanicSpaceship.MechanicState == MechanicType.Loading)
            {
                //mechanic spaceship has no fuel
                return _stateHandler.DriveState;
            }
        }
        return this;
    }
}
