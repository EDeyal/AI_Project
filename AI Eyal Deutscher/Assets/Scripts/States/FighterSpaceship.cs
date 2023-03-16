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
        else
        {
            UpdateStateMachine(FighterStateHandler.ReloadAmmunition);
        }
    }
    private void Shoot()
    {
        Instantiate(_ammoPrefab,transform,false);
        StartCoroutine(WaitOneSecond());
    }
}
