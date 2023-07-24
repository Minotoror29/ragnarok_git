using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TableTurnState : State
{
    protected TableTurnManager _tableTurnManager;

    public TableTurnState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager)
    {
        _tableTurnManager = tableTurnManager;
    }

    public virtual void SelectDeck(Deck deck, Card card) { }

    public virtual void SelectPlayer(Player selectedPlayer) { }
}
