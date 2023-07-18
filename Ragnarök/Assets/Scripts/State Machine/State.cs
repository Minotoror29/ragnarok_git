using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateManager _stateManager;

    public State(StateManager stateManager)
    {
        _stateManager = stateManager;
    }

    public abstract void Enter();
    public abstract void UpdateLogic();
    public abstract void Exit();
}
