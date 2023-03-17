using UnityEngine;

public class ShootingState : BaseState
{
    public override BaseState RunCurrentState()
    {
        if (_spaceship is FighterSpaceship fighter)
        {
            if (fighter.CurrentAmmunition>0)
            {
                _spaceship.Act();
                return this;

            }
            return _stateHandler.DriveState;
        }
        Debug.LogError("Wrong Car is trying to shoot");
        return _stateHandler.IdleState;
    }
}
