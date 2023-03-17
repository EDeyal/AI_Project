public class RefuelState : BaseState
{
    public override BaseState RunCurrentState()
    {
        if (_stateHandler.Spaceship.CheckIfFueledUp())
        {
            return _stateHandler.DriveState;
        }
        _stateHandler.Spaceship.RefuelSpaceship();
        return this;
    }
}
