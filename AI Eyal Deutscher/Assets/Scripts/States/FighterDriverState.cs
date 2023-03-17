public class FighterDriverState : FighterBaseState
{
    BaseState _nextState;
    public override BaseState RunCurrentState()
    {
        if (!FighterStateHandler.Spaceship .ReachedDestination)
        {
            FighterStateHandler.Spaceship.MoveToLocation(StationsManager.Instance.GetNextStation(FighterStateHandler.Spaceship, out BaseState nextState));
            _nextState = nextState;
            return this;
        }
        return _nextState;
    }
    public override void ExitState()
    {
        base.ExitState();
        FighterStateHandler.Spaceship.ReachedDestination = false;
    }
}
