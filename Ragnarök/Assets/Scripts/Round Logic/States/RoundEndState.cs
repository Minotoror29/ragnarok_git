using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : RoundState
{
    public RoundEndState(StateManager stateManager, RoundManager roundManager, int roundNumber) : base(stateManager, roundManager, roundNumber)
    {
    }

    public override void Enter()
    {
        _roundManager.EndRoundDisplay.gameObject.SetActive(true);
        _roundManager.EndRoundDisplay.SetState(this);
        _roundManager.EndRoundDisplay.SetTitle(_roundNumber);
        _roundManager.EndRoundDisplay.SetWinnerText(_roundManager.DetermineRoundWinners());
    }

    public override void Exit()
    {
        _roundManager.EndRoundDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public void NextRound()
    {
        _roundManager.EndRoundDisplay.gameObject.SetActive(false);
        _roundManager.MatchRoundState.RoundEnd();
    }
}
