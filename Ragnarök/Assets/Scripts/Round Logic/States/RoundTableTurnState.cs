using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTableTurnState : RoundState
{
    private int _currentTableTurn;

    public RoundTableTurnState(StateManager stateManager, RoundManager roundManager, int roundNumber, int previoustableTurnIndex) : base(stateManager, roundManager, roundNumber)
    {
        _currentTableTurn = previoustableTurnIndex + 1;
    }

    public override void Enter()
    {
        _roundManager.TableTurnManager.StartTableTurn(this);
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
        _roundManager.TableTurnManager.UpdateLogic();
    }

    public void TableTurnEnd()
    {
        if (_currentTableTurn == _roundManager.MaxTableTurns)
        {
            _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber));
        } else
        {
            _stateManager.ChangeState(new RoundTableTurnState(_stateManager, _roundManager, _roundNumber, _currentTableTurn));
        }
    }

    public void EndRound()
    {
        _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber));
    }

}
