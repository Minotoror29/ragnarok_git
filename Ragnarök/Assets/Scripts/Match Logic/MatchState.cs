using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MatchState : State
{
    protected MatchManager _matchManager;

    public MatchState(StateManager stateManager, MatchManager matchManager) : base(stateManager)
    {
        _matchManager = matchManager;
    }
}
