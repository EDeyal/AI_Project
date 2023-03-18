using UnityEngine;

public class FighterSpaceship : BaseSpaceship
{
    
    [SerializeField] int _maxAmmunition;
    int _currentAmmunition;
    [SerializeField] GameObject _ammoPrefab;
    public FighterStateHandler FighterStateHandler => StateHandler as FighterStateHandler;
    public int CurrentAmmunition => _currentAmmunition;
    override protected void Awake()
    {
        base.Awake();
        _currentAmmunition = _maxAmmunition;
    }
    public override void Act()
    {
        base.Act();
        TryShoot();
    }
    private void TryShoot()
    {
        if (_isWaiting)
        {
            return;
        }
        Debug.Log("Trying to Shoot");
        if (_currentAmmunition > 0)
        {
            _currentAmmunition--;
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(_ammoPrefab,transform,false);
        StartCoroutine(WaitOneSecond());
    }
    public bool CheckIfAmmoIsFull()
    {
        if (_currentAmmunition<_maxAmmunition)
        {
            return false;
        }
        return true;
    }
    public void RefillAmmo()
    {
        if (_isWaiting)
        {
            return;
        }
        if (StationsManager.Instance.AmmoInAmmunitionStation > 0)
        {
            StationsManager.Instance.AmmoInAmmunitionStation--;
            _currentAmmunition++;
        }
        else
        {
            Debug.Log("Ammunition Station does not have enough Ammo");
        }
        StartCoroutine(WaitOneSecond());

    }
}
