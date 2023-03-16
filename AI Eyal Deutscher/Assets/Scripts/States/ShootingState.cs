public class ShootingState : BaseState
{
    public override BaseState RunCurrentState()
    {
        _spaceship.Act();
        return this;
    }
}
