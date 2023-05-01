using UnityEngine;
public enum MechanicType
{
    Loading = 0,
    Repairing = 1
}
public class MechanicSpaceship : BaseSpaceship
{
    public MechanicStateHandler MechanicStateHandler => StateHandler as MechanicStateHandler;
    public BaseSpaceship StuckSpaceship { set => _stuckSpaceship = value; }
    //[SerializeField] float _maxFuelTankAmount;
    float _currentFuelTankAmount;
    //[SerializeField] float _loadAmount;
    [SerializeField] MechanicType _mechanicState;
    BaseSpaceship _stuckSpaceship;
    public MechanicType MechanicState => _mechanicState;
    public float CurrentFuelTankAmount => _currentFuelTankAmount;
    public override void Act()
    {
        base.Act();
    }
    public bool IsFuelLoaded()
    {
        if (_isWaiting)
            return false;

        if (_currentFuelTankAmount < _spaceshipDataSO.MaxMechanicFuelTankAmount)
        {
            _currentFuelTankAmount += _spaceshipDataSO.MechanicLoadAmount;
            StartCoroutine(WaitOneSecond());
            return false;
        }
        _mechanicState = MechanicType.Repairing;
        return true;
    }
    public bool IsSpaceshipRepaired()
    {
        if (_isWaiting)
            return false;
        if (_stuckSpaceship == null)
        {
            Debug.LogError("Mechanic Spaceship has no stuck spaceship");
            return false;
        }
        if (_currentFuelTankAmount > 0)
        {
            _currentFuelTankAmount -= _spaceshipDataSO.MechanicLoadAmount;
            if (_stuckSpaceship.IsAddingFuel(_spaceshipDataSO.MechanicLoadAmount))
            {
                StartCoroutine(WaitOneSecond());
                return false;
            }
            else
            {
                _stuckSpaceship = null; //spaceship is repaired 
                return true;
            }
        }
        _mechanicState = MechanicType.Loading;
        return false;
    }
}
