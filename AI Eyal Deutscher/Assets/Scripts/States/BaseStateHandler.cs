using UnityEngine;

public class BaseStateHandler : MonoBehaviour, ICheckValidation
{
    [SerializeField] BaseState _startingState;
    [SerializeField] BaseState _idleState;
    [SerializeField] BaseState _actionState;
    [SerializeField] BaseState _fuelState;
    [SerializeField] BaseState _repairState;
    [SerializeField] BaseState _driveState;

    BaseState _currentState;

    protected BaseSpaceship _spaceship;

    public BaseState CurrentState { get => _currentState; set => _currentState = value; }
    public BaseState ActionState => _actionState;
    public BaseState IdleState => _idleState;
    public BaseState FuelState => _fuelState;
    public BaseState RepairState => _repairState;
    public BaseState DriveState => _driveState;
    public BaseSpaceship Spaceship => _spaceship;
    public void CacheShip(BaseSpaceship currentSpaceship)
    {
        _spaceship = currentSpaceship;
    }
    public virtual void CheckValidation()
    {
        if (_startingState == null)        
            throw new System.Exception("starting state is null");
        if (_idleState == null)
            throw new System.Exception("Idle state is Null");
        if (_actionState == null)
            throw new System.Exception("Action state is Null");
        if (_fuelState == null)
            throw new System.Exception("Fuel state is Null");
        if (_repairState == null)
            throw new System.Exception("Repair state is Null");
        if (_driveState == null)
            throw new System.Exception("Drive state is null");
    }
    private void OnEnable()
    {
        _currentState = _startingState;
    }
    private void Awake()
    {
        CheckValidation();
    }
}
