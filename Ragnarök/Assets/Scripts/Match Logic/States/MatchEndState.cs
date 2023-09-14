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
        if (_ragnarok)
        {
            _matchManager.EndMatchDisplay.gameObject.SetActive(true);
        }
        else
        {
            _matchManager.TitlesDisplay.gameObject.SetActive(true);
            _matchManager.TitlesDisplay.DetermineTitles(_matchManager.Players, _matchManager.DetermineMatchWinners(_ragnarok));
        }
    }

    public override void Exit()
    {
        _matchManager.TitlesDisplay.gameObject.SetActive(false);
        _matchManager.EndMatchDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
