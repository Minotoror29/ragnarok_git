using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : RoundState
{
    private bool _ragnarok;

    public RoundEndState(StateManager stateManager, RoundManager roundManager, int roundNumber, bool ragnarok) : base(stateManager, roundManager, roundNumber)
    {
        _ragnarok = ragnarok;
    }

    public override void Enter()
    {
        _roundManager.EndRoundDisplay.gameObject.SetActive(true);
        _roundManager.EndRoundDisplay.SetState(this);
        _roundManager.EndRoundDisplay.SetTitle(_roundNumber);
        _roundManager.EndRoundDisplay.SetWinnerText(_roundManager.DetermineRoundWinners(_ragnarok));

        foreach (Player player in _roundManager.ActivePlayers)
        {
            player.TitlePoints[TitlePointsId.TotalPower] += player.Points;
        }
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
        _roundManager.MatchRoundState.RoundEnd(_ragnarok);
    }
}
