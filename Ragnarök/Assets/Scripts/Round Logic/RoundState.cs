using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoundState : State
{
    protected RoundManager _roundManager;
    protected int _roundNumber;

    public RoundState(StateManager stateManager, RoundManager roundManager, int roundNumber) : base (stateManager)
    {
        _roundManager = roundManager;
        _roundNumber = roundNumber;
    }
}
