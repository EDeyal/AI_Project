using UnityEngine;

public class LoadFuelState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Loading Ammo");
        if (/*load fuel action from bool method*/0==0)
        {
            if (StationsManager.Instance.StuckCars.Count > 0)
            {
                //go and repair the car with drive state or repair state
            }
        }
        return this;
    }
}
