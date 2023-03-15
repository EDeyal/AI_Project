using UnityEngine;

public class BaseSpaceship : MonoBehaviour, ICheckValidation
{
    [SerializeField] BaseStateHandler _stateHandler;
    [SerializeField] Rigidbody _rigidbody;
    [SerializeField] float _speed;
    [SerializeField] float _movementOffset;
    [SerializeField] float _maxFuel;
    float _currentFuel;
    bool _reachedDestination;
    bool _hasMalfunction;

    public bool ReachedDestination { get => _reachedDestination; set => _reachedDestination = value; }
    public bool HasMalfanction => _hasMalfunction;
    public float CurrentFuel => _currentFuel;
    public BaseStateHandler StateHandler=> _stateHandler;
    private void Awake()
    {
        CheckValidation();
        _stateHandler.CacheShip(this);
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
            Vector3 movement = transform.position + targetLocation.normalized * Time.deltaTime * _speed;
            _rigidbody.MovePosition(movement);
        }
        else
        {
            _reachedDestination = true;
        }
    }

    public void CheckValidation()
    {
        if (!_rigidbody)
            throw new System.Exception("BaseSpaceship has no rigidbody");
    }
}
