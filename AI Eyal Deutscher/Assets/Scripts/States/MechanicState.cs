using UnityEngine;

public class MechanicState : MechanicBaseState
{

    public override BaseState RunCurrentState()
    {
        Debug.Log("Mechanic stuff");
        return this;
    }
}
