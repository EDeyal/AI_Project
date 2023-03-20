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
    public override void EnterState()
    {
        base.EnterState();
        StationsManager.Instance.StuckSpaceships.Add(_stateHandler.Spaceship);

    }
    public override void ExitState()
    {
        base.ExitState();
        StationsManager.Instance.StuckSpaceships.Remove(_stateHandler.Spaceship);
    }
}
