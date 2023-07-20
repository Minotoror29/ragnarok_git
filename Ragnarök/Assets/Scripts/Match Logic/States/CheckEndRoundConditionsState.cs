using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEndRoundConditionsState : MatchState
{
    private Player _currentPlayer;

    public CheckEndRoundConditionsState(StateManager stateManager, MatchManager matchManager, Player currentPlayer) : base(stateManager, matchManager)
    {
        _currentPlayer = currentPlayer;
    }

    public override void Enter()
    {
        if (_matchManager.Clock.IsAtMidnight() ||
            _matchManager.RoundManager.ActivePlayers.Count == 1 ||
            _matchManager.RoundManager.ActivePlayers.Count == 0 ||
            (_matchManager.RoundManager.CurrentTableTurn == _matchManager.RoundManager.MaxTableTurns &&
            _matchManager.RoundManager.ActivePlayers.IndexOf(_currentPlayer) == _matchManager.RoundManager.ActivePlayers.Count - 1))
        {
            _stateManager.ChangeState(new RoundEndState(_stateManager, _matchManager));
        } else
        {
            //_stateManager.ChangeState(new TableTurnTransitionState(_stateManager, _matchManager, _matchManager.GetNextPlayer(_currentPlayer)));
        }
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
