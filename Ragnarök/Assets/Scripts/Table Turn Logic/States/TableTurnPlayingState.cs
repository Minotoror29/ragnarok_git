using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnPlayingState : TableTurnState
{
    private Player _player;

    public TableTurnPlayingState(StateManager stateManager, TableTurnManager tableTurnManager, Player player) : base(stateManager, tableTurnManager)
    {
        _player = player;
    }

    public override void Enter()
    {
        _player.StartPlayerTurn();
        TableTurnManager.SelectionManager.Enable(this);

        if (_player.MustSkipNextTurn)
        {
            _player.EndPlayerTurn();
            TableTurnManager.ActivePlayers.Remove(_player);
            _stateManager.ChangeState(new TableTurnCheckState(_stateManager, TableTurnManager));
        } else
        {
            _stateManager.ChangeState(new TableTurnCardState(_stateManager, TableTurnManager, _player, TableTurnManager.Deck.DrawCard()));
        }
    }

    public override void Exit()
    {
        TableTurnManager.SelectionManager.Disable();
    }

    public override void UpdateLogic()
    {
        TableTurnManager.SelectionManager.UpdateLogic();
    }
}
