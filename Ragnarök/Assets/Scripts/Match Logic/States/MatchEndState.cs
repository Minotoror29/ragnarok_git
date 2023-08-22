using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchEndState : MatchState
{
    private bool _ragnarok;

    public MatchEndState(StateManager stateManager, MatchManager matchManager, bool ragnarok) : base(stateManager, matchManager)
    {
        _matchManager = matchManager;
        _ragnarok = ragnarok;
    }

    public override void Enter()
    {
        //_matchManager.EndMatchDisplay.gameObject.SetActive(true);
        //_matchManager.EndMatchDisplay.SetWinnersText(_matchManager.DetermineMatchWinners(_ragnarok));

        _matchManager.TitlesDisplay.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        _matchManager.EndMatchDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
