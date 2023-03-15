public class FighterDriverState : BaseDriveState
{
    BaseState _nextState;
    public override BaseState RunCurrentState()
    {
        if (!_spaceship.ReachedDestination)
        {
            _spaceship.MoveToLocation(StationsManager.Instance.GetNextStation(_spaceship,out BaseState nextState));
            _nextState = nextState;
            return this;
        }
        return _nextState;
    }
}
