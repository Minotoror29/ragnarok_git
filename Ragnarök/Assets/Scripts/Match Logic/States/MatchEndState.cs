using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEndState : MatchState
{
    public MatchEndState(StateManager stateManager, MatchManager matchManager) : base(stateManager, matchManager)
    {
        _matchManager = matchManager;
    }

    public override void Enter()
    {
        _matchManager.EndMatchDisplay.gameObject.SetActive(true);
        _matchManager.EndMatchDisplay.SetWinnersText(_matchManager.DetermineMatchWinners());
    }

    public override void Exit()
    {
        _matchManager.EndMatchDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
