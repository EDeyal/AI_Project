
public class ReloadAmmunitionState : FighterBaseState
{
    public override BaseState RunCurrentState()
    {
        if (FighterStateHandler.FighterSpaceship.CheckIfAmmoIsFull())
        {
            return FighterStateHandler.DriveState;
        }
        FighterStateHandler.FighterSpaceship.RefillAmmo();
        return this;
    }
}
