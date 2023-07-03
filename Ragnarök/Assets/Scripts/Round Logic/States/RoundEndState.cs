using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundEndState : State
{
    private EndRoundDisplay _endRoundDisplay;
    private int _roundNumber;
    private List<Player> _winners;

    public RoundEndState(EndRoundDisplay endRoundDisplay, int roundNumber, List<Player> winners)
    {
        _endRoundDisplay = endRoundDisplay;
        _roundNumber = roundNumber;
        _winners = winners;
    }

    public override void Enter()
    {
        _endRoundDisplay.gameObject.SetActive(true);
        _endRoundDisplay.SetTitle(_roundNumber);
        _endRoundDisplay.SetWinnerText(_winners);
    }

    public override void Exit()
    {
        _endRoundDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
