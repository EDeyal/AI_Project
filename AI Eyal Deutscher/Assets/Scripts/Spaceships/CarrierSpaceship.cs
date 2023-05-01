using UnityEngine;
public enum CarrierStateType
{
    Loading = 0,
    Unloading = 1
}
public class CarrierSpaceship : BaseSpaceship
{
    //[SerializeField] float _maxCarryWeight;
    //[SerializeField] float _loadAmount = 1;
    CarrierStateType _carrierState;
    float _currentCarryWeight;
    public CarrierStateHandler CarrierStateHandler => StateHandler as CarrierStateHandler;
    public float CurrentCarryWeight => _currentCarryWeight;
    public CarrierStateType CarrierState =>_carrierState;
    public override void Act()
    {
        base.Act();
        IsCarrierLoaded();
    }
    public bool IsCarrierLoaded()
    {
        if(_isWaiting)
            return false;

        if (_currentCarryWeight < _spaceshipDataSO.MaxCarryWeight)
        {
            _currentCarryWeight+= _spaceshipDataSO.CarrierLoadAmount;
            StartCoroutine(WaitOneSecond());
            return false;
        }
        _carrierState = CarrierStateType.Unloading;
        return true;
    }
    public bool IsCarrierUnloaded()
    {
        if (_isWaiting)
            return false;

        if (_currentCarryWeight > 0)
        {
            _currentCarryWeight-= _spaceshipDataSO.CarrierLoadAmount;
            StationsManager.Instance.AmmoInAmmunitionStation+= _spaceshipDataSO.CarrierLoadAmount;
            StartCoroutine(WaitOneSecond());
            return false;
        }
        _carrierState = CarrierStateType.Loading;
        return true;
    }
}
