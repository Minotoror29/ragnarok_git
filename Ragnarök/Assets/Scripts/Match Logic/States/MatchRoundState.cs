using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRoundState : MatchState
{
    private int _currentRound;

    public MatchRoundState(StateManager stateManager, MatchManager matchManager, int previousRoundIndex) : base(stateManager, matchManager)
    {
        _currentRound = previousRoundIndex + 1;
    }

    public override void Enter()
    {
        if (_currentRound == 1)
        {
            _matchManager.RoundManager.StartRound(this, _currentRound, _matchManager.DeterminePlayerOrder(_matchManager.GetRandomPlayer(_matchManager.Players)));
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

    public void RoundEnd()
    {
        if (_currentRound < _matchManager.MaxRounds)
        {
            _stateManager.ChangeState(new MatchRoundState(_stateManager, _matchManager, _currentRound));
        } else if (_currentRound == _matchManager.MaxRounds)
        {
            _stateManager.ChangeState(new MatchEndState(_stateManager, _matchManager));
        }
    }
}
