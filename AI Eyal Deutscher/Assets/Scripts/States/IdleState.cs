using System.Collections;
using UnityEngine;
public class IdleState : BaseState
{
    [SerializeField] float _idleTime;
    bool _isRunning;
    bool _isCompleted;
    public override BaseState RunCurrentState()
    {
        if (_isCompleted)
        {
            _isCompleted = false;
            return _stateHandler.DriveState;
        }
        if (!_isRunning)
        {
            StartCoroutine(WaitForIdle());
        }
        return this;
    }
    IEnumerator WaitForIdle()
    {
        _isRunning = true;
        yield return new WaitForSeconds(_idleTime);
        _isCompleted = true;
    }
}
