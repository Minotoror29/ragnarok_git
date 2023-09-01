using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableTurnState : State
{
    private TableTurnManager _tableTurnManager;

    public TableTurnManager TableTurnManager { get { return _tableTurnManager; } }

    public TableTurnState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager)
    {
        _tableTurnManager = tableTurnManager;
    }

    public virtual void SelectPlayer(Player selectedPlayer) { }
}
