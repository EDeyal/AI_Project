public class MechanicIdleState : MechanicBaseState
{
    public override BaseState RunCurrentState()
    {
        if (StationsManager.Instance.StuckSpaceships.Count > 0)
        {
            return _stateHandler.DriveState;
        }
        else
        {
            return this;
        }
    }
}
