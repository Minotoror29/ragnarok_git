using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableTurnState : State
{
    protected TableTurnManager _tableTurnManager;
    protected Player _player;

    public TableTurnState(StateManager stateManager, TableTurnManager tableTurnManager, Player player) : base(stateManager)
    {
        _tableTurnManager = tableTurnManager;
        _player = player;
    }
}
