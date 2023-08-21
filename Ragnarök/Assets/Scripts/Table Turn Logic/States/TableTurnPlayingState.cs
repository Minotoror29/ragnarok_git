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
        _tableTurnManager.SelectionManager.Enable(this);

        if (_player.MustSkipNextTurn)
        {
            _player.EndPlayerTurn();
            _tableTurnManager.ActivePlayers.Remove(_player);
            _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager, _player.VCam));
        } else
        {
            _stateManager.ChangeState(new TableTurnCardState(_stateManager, _tableTurnManager, _player, _tableTurnManager.Deck.DrawCard()));
        }
    }

    public override void Exit()
    {
        _tableTurnManager.SelectionManager.Disable();
    }

    public override void UpdateLogic()
    {
        _tableTurnManager.SelectionManager.UpdateLogic();
    }
}
