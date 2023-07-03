using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEndState : State
{
    private EndMatchDisplay _endMatchDisplay;
    private List<Player> _winners;

    public MatchEndState(EndMatchDisplay endMatchDisplay, List<Player> winners)
    {
        _endMatchDisplay = endMatchDisplay;
        _winners = winners;
    }

    public override void Enter()
    {
        _endMatchDisplay.gameObject.SetActive(true);
        _endMatchDisplay.SetWinnersText(_winners);
    }

    public override void Exit()
    {
        _endMatchDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
