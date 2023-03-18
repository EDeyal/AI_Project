using UnityEngine;
public class UnloadAmmo : CarrierBaseState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Unloading Ammo");
        if (CarrierStateHandler.CarrierSpaceship.IsCarrierUnloaded())
        {
            return _stateHandler.DriveState;
        }
        return this;
    }
}
