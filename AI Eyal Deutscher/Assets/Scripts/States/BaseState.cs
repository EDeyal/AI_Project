using System;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    [SerializeField] protected BaseStateHandler _stateHandler;
    protected BaseSpaceship _spaceship;

    public event Action OnStateEnter;
    public event Action OnStateExit;
    public abstract BaseState RunCurrentState();
    public void CacheShip(BaseSpaceship currentSpaceship)
    {
        _spaceship = currentSpaceship;
    }
    public virtual void EnterState()
    {
        OnStateEnter?.Invoke();
    }
    public virtual void ExitState()
    {
        OnStateExit?.Invoke();
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
