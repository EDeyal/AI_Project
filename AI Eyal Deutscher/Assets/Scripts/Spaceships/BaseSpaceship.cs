using System.Collections;
using UnityEngine;

public class BaseSpaceship : MonoBehaviour, ICheckValidation
{
    [SerializeField] BaseStateHandler _stateHandler;
    [SerializeField] protected SpaceshipDataSO _spaceshipDataSO;
    [SerializeField] Rigidbody _rigidbody;
    //[SerializeField] float _speed;
    [SerializeField] float _movementOffset;
    //[SerializeField] float _maxFuel;
    //[SerializeField] float _malfunctionChance;
    //[SerializeField] float _repairTime;
    //[SerializeField,Range(0,100)] float _lowFuelPrecentage;
    //[SerializeField] SpaceshipType _spaceshipType;
    float _currentFuel;
    bool _reachedDestination;
    bool _hasMalfunction;
    protected bool _isWaiting;
    public SpaceshipType SpaceshipType => _spaceshipDataSO.SpaceshipType;
    public bool ReachedDestination
    {
        get
        {
            return _reachedDestination;
        }
        set
        {
            _reachedDestination = value;
            Debug.Log($"Reached Destination of {gameObject.name} is being changed to: {_reachedDestination}");
        }
    }
    public bool HasMalfunction => _hasMalfunction;
    public float CurrentFuel => _currentFuel;
    public bool IsWaiting { set => _isWaiting = value; }
    public BaseStateHandler StateHandler => _stateHandler;
    protected virtual void Awake()
    {
        CheckValidation();
        _stateHandler.CacheShip(this);
        _currentFuel = _spaceshipDataSO.MaxFuel;
    }
    private void Update()
    {
        BaseState NextState = _stateHandler.CurrentState.RunCurrentState();
        UpdateStateMachine(NextState);
    }
    public void UpdateStateMachine(BaseState nextState)
    {
        if (_stateHandler.CurrentState != nextState)
        {
            _stateHandler.CurrentState.ExitState();
            _stateHandler.CurrentState = nextState;
            _stateHandler.CurrentState.EnterState();
        }
    }
    public void MoveToLocation(Vector3 targetLocation)
    {
        if (Vector3.Distance(transform.position, targetLocation) > _movementOffset)
        {
            Vector3 movementVector = Vector3.MoveTowards(transform.position, targetLocation, Time.deltaTime * _spaceshipDataSO.Speed);
            transform.LookAt(targetLocation);
            //Vector3 movement = transform.position + targetLocation.normalized * Time.deltaTime * _speed;
            ReduceFuelAmount();
            _rigidbody.MovePosition(movementVector);
        }
        else
        {
            ReachedDestination = true;
        }
    }
    private void ReduceFuelAmount()
    {
        _currentFuel -= Time.deltaTime;
        //Debug.Log("Current fuel is: " + CurrentFuel);
    }
    public void CheckValidation()
    {
        if (!_rigidbody)
            throw new System.Exception("BaseSpaceship has no rigidbody");
        if (!_spaceshipDataSO)
            throw new System.Exception("BaseSpaceship has no DataSO");
    }
    public void CheckForMalfunctions()
    {
        if (_isWaiting)
        {
            return;
        }
        Debug.Log("Checking for malfunctions");
        int malfunctionChance = Random.Range(0, 100);
        if (malfunctionChance < _spaceshipDataSO.MalfunctionChance)
        {
            _hasMalfunction = true;
        }
        StartCoroutine(WaitOneSecond());
    }
    protected IEnumerator WaitOneSecond()
    {
        _isWaiting = true;
        yield return new WaitForSeconds(1);
        _isWaiting = false;
    }

    public virtual void Act()
    {
        //will be implemented differently for each inherited class
        //shooter spaceship
        //mechanic spaceship
        //ammunition spaceship
    }
    public bool CheckIfFueledUp()
    {
        if (_currentFuel < _spaceshipDataSO.MaxFuel)
        {
            return false;
        }
        Debug.Log("Fuel is Full");
        return true;
    }
    public bool CheckIfLowFuel()
    {
        if (_currentFuel/ _spaceshipDataSO .MaxFuel* 100 <= _spaceshipDataSO.LowFuelPrecentage)
        {
            Debug.Log(gameObject.name + " has low levels of fuel");
            return true;
        }
        return false;
    }
    public void RefuelSpaceship()
    {
        if (_isWaiting)
        {
            return;
        }
        _currentFuel++;
        StartCoroutine(WaitOneSecond());
    }

    public void RepairVehicle()
    {
        //Debug.Log("Spaceship Trying to repair Malfunction");

        if (_isWaiting)
        { return; }
        StartCoroutine(WaitForRepair());
    }
    protected IEnumerator WaitForRepair()
    {
        _isWaiting = true;
        yield return new WaitForSeconds(_spaceshipDataSO.RepairTime);
        Debug.Log(gameObject.name + " Vehicle Repaired");
        _hasMalfunction = false;
        _isWaiting = false;
    }
    //Method for mechanics only will repair the vehicle on max fuel
    public bool IsAddingFuel(float amount)
    {
        if (_currentFuel >= _spaceshipDataSO.MaxFuel)
        {
            _hasMalfunction = false;
            return false;
        }
        else
        {
            _currentFuel += amount;
            return true;
        }
    }
}
