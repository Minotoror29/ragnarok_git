using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private State _currentState;

    public void ChangeState(State nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = nextState;
        _currentState.Enter();
    }

    public void UpdateLogic()
    {
        _currentState.UpdateLogic();
    }
}
