using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : State
{
    private MatchManager _matchManager;

    public RoundEndState(StateManager stateManager, MatchManager matchManager) : base(stateManager)
    {
        _matchManager = matchManager;
    }

    public override void Enter()
    {
        _matchManager.RoundManager.EndRound();
        _matchManager.DisplayEndRoundCanvas(true, this);
    }

    public override void Exit()
    {
        _matchManager.DisplayEndRoundCanvas(false);
    }

    public override void UpdateLogic()
    {
    }

    public void NextRound()
    {
        _stateManager.ChangeState(new TransitionState(_stateManager, _matchManager, _matchManager.GetPlayerWithLessPoints()));
    }

    public void Endmatch()
    {
        _stateManager.ChangeState(new MatchEndState(_stateManager, _matchManager));
    }
}
