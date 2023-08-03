using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStartState : MatchState
{
    private bool _firstMatch;

    public MatchStartState(StateManager stateManager, MatchManager matchManager, bool firstMatch) : base(stateManager, matchManager)
    {
        _firstMatch = firstMatch;
    }

    public override void Enter()
    {
        Player startingPlayer;

        if (_firstMatch)
        {
            startingPlayer = _matchManager.GetRandomPlayer(_matchManager.Players);
        } else
        {
            startingPlayer = _matchManager.GetPlayerWhoWonLessRounds();
        }

        foreach (var player in _matchManager.Players)
        {
            player.RoundsWon = 0;
        }

        _stateManager.ChangeState(new MatchRoundState(_stateManager, _matchManager, startingPlayer, 0));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
