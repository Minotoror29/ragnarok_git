using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnCheckState : TableTurnState
{
    private Player _player;

    public TableTurnCheckState(StateManager stateManager, TableTurnManager tableTurnManager, Player player) : base(stateManager, tableTurnManager)
    {
        _player = player;
    }

    public override void Enter()
    {
        _player.EndPlayerTurn();

        _tableTurnManager.ActivePlayers.Remove(_player);

        if (!_tableTurnManager.RoundState.IsRoundOver())
        {
            if (_tableTurnManager.ActivePlayers.Count == 0)
            {
                _stateManager.ChangeState(new TableTurnEndState(_stateManager, _tableTurnManager));
            }
            else
            {
                _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, _tableTurnManager, _tableTurnManager.ActivePlayers[0]));
            }
        }

        //if (_tableTurnManager.Clock.IsAtMidnight() ||
        //    _tableTurnManager.ActivePlayers.Count == 1 ||
        //    _tableTurnManager.ActivePlayers.Count == 0)
        //{
        //    _tableTurnManager.RoundState.EndRound();
        //} else if (_player == _tableTurnManager.ActivePlayers[^1])
        //{
        //    _stateManager.ChangeState(new TableTurnEndState(_stateManager, _tableTurnManager));
        //} else
        //{
        //    _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, _tableTurnManager, _tableTurnManager.GetNextPlayer(_player)));
        //}
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
