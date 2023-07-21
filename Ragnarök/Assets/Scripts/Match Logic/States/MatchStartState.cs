using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStartState : MatchState
{
    public MatchStartState(StateManager stateManager, MatchManager matchManager) : base(stateManager, matchManager)
    {
    }

    public override void Enter()
    {
        _stateManager.ChangeState(new MatchRoundState(_stateManager, _matchManager, 0));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
