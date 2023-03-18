using UnityEngine;
public class LoadAmmoState : CarrierBaseState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Loading Ammo");
        if (CarrierStateHandler.CarrierSpaceship.IsCarrierLoaded())
        {
            return _stateHandler.DriveState;
        }
        return this;
    }
}
