public class RepairState : BaseState
{
    public override BaseState RunCurrentState()
    {
        if (_stateHandler.Spaceship.HasMalfunction)
        {
            _stateHandler.Spaceship.RepairVehicle();
            return this;
        }
        else
        {
            return _stateHandler.DriveState;
        }
    }
}
