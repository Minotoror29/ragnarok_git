using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRoundState : MatchState
{
    private Player _startingPlayer;
    private int _currentRound;

    public MatchRoundState(StateManager stateManager, MatchManager matchManager, Player startingPlayer, int previousRoundIndex) : base(stateManager, matchManager)
    {
        _startingPlayer = startingPlayer;
        _currentRound = previousRoundIndex + 1;
    }

    public override void Enter()
    {
        if (_currentRound == 1)
        {
            _matchManager.RoundManager.StartRound(this, _currentRound, _matchManager.DeterminePlayerOrder(_startingPlayer));
        } else if (_currentRound > 1)
        {
            _matchManager.RoundManager.StartRound(this, _currentRound, _matchManager.DeterminePlayerOrder(_matchManager.GetPlayerWithLessPoints()));
        }
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
        _matchManager.RoundManager.Updatelogic();
    }

    public void RoundEnd(bool ragnarok)
    {
        if (_currentRound < _matchManager.MaxRounds)
        {
            _stateManager.ChangeState(new MatchRoundState(_stateManager, _matchManager, _startingPlayer, _currentRound));
        } else if (_currentRound == _matchManager.MaxRounds)
        {
            _stateManager.ChangeState(new MatchEndState(_stateManager, _matchManager, ragnarok));
        }
    }
}
