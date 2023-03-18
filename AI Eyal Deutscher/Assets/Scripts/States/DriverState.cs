using UnityEngine;

public class DriverState : BaseState
{
    BaseState _nextState;
    public override BaseState RunCurrentState()
    {
        if (!_stateHandler.Spaceship .ReachedDestination)
        {
            if (_stateHandler.Spaceship.CurrentFuel<=0)
            {
                return _stateHandler.StuckState;
            }
            Debug.Log(_stateHandler.Spaceship.name+" Is Driving");
            _stateHandler.Spaceship.MoveToLocation(StationsManager.Instance.GetNextStation(_stateHandler.Spaceship, out BaseState nextState));
            _nextState = nextState;
            return this;
        }
        return _nextState;
    }
    public override void ExitState()
    {
        base.ExitState();
        _stateHandler.Spaceship.ReachedDestination = false;
    }
}
