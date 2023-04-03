using UnityEngine;
public class MechanicIdleState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        if (StationsManager.Instance.StuckSpaceships.Count > 0)
        {
            Debug.Log("Mechanic is going to repair spaceship");
            return _stateHandler.DriveState;
        }
        else
        {
            return this;
        }
    }
}
