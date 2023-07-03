using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnPlayerState : TableTurnState
{
    public TableTurnPlayerState(TableTurnManager tableTurnManager, Player player) : base(tableTurnManager, player)
    {
        
    }

    public override void Enter()
    {
        _player.StartPlayerTurn();
    }

    public override void Exit()
    {
        //_player.EndPlayerTurn();
    }

    public override void UpdateLogic()
    {
        _player.UpdateLogic();
    }
}
