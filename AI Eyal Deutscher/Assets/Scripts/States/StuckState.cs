using UnityEngine;
public class StuckState : BaseState
{
    public override BaseState RunCurrentState()
    {
        Debug.Log("Spaceship is stuck");

        if (_stateHandler.Spaceship.CheckIfFueledUp())
        {
            return _stateHandler.DriveState;
        }
        return this;
    }
}
