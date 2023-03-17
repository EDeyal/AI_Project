using System;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    [SerializeField] protected BaseStateHandler _stateHandler;

    public event Action OnStateEnter;
    public event Action OnStateExit;
    public abstract BaseState RunCurrentState();

    public virtual void EnterState()
    {
        OnStateEnter?.Invoke();
    }
    public virtual void ExitState()
    {
        OnStateExit?.Invoke();
        _stateHandler.Spaceship.IsWaiting = false;
    }
    public virtual void UpdateState()
    {
    }
    private void OnValidate()
    {
        if(!_stateHandler)
        {
            _stateHandler = GetComponent<BaseStateHandler>();
        }
    }
}
