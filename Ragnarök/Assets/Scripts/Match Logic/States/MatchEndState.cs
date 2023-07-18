using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEndState : State
{
    private MatchManager _matchManager;

    public MatchEndState(StateManager stateManager, MatchManager matchManager) : base(stateManager)
    {
        _matchManager = matchManager;
    }

    public override void Enter()
    {
        _matchManager.DisplayEndMatchCanvas(true);
    }

    public override void Exit()
    {
        _matchManager.DisplayEndMatchCanvas(false);
    }

    public override void UpdateLogic()
    {
    }
}
