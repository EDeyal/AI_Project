using System;
using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
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
    }
    public virtual void UpdateState()
    {
    }
}
