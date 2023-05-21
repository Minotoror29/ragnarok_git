using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnPlayerState : State
{
    private TableTurnManager _tableTurnManager;
    private Player _player;

    public TableTurnPlayerState(TableTurnManager tableTurnManager, Player player)
    {
        _tableTurnManager = tableTurnManager;
        _player = player;
    }

    public override void Enter()
    {
        _player.StartPlayerTurn();
    }

    public override void Exit()
    {
        _player.EndPlayerTurn();
    }

    public override void UpdateLogic()
    {
        
    }
}
