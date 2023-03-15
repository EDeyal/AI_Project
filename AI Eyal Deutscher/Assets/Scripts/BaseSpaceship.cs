using UnityEngine;

public class BaseSpaceship : MonoBehaviour, ICheckValidation
{
    [SerializeField] BaseStateHandler _stateHandler;
    [SerializeField] Rigidbody _rigidbody;
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
        _rigidbody.MovePosition(targetLocation);
    }

    public void CheckValidation()
    {
        if (!_rigidbody)
            throw new System.Exception("BaseSpaceship has no rigidbody");
    }
}
