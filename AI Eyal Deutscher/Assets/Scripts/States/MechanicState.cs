using UnityEngine;

public class MechanicState : MechanicBaseState
{
    protected CarrierStateHandler CarrierStateHandler => _stateHandler as CarrierStateHandler;

    public override BaseState RunCurrentState()
    {
        Debug.Log("Mechanic stuff");
        return this;
    }
}
