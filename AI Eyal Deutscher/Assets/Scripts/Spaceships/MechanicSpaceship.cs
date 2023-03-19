public class MechanicSpaceship : BaseSpaceship
{
    public MechanicStateHandler MechanicStateHandler => StateHandler as MechanicStateHandler;

    float _extraFuelTank;
    public override void Act()
    {
        base.Act();

    }

}
