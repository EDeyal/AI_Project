using UnityEngine;

public class MechanicRepairState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Mechanic is repairing car");
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
