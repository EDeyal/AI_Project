public class ShootingState : FighterBaseState
{
    public override BaseState RunCurrentState()
    {
        if (FighterStateHandler.FighterSpaceship.CurrentAmmunition > 0)
        {
            FighterStateHandler.FighterSpaceship.Act();
            return this;
        }
        return _stateHandler.DriveState;
    }
}
