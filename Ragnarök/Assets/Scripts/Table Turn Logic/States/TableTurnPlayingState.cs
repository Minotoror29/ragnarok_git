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
            _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager, _player));
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

    public override void SelectDeck(Deck deck, Card card)
    {
        base.SelectDeck(deck, card);

        deck.DrawCard();
        _stateManager.ChangeState(new TableTurnCardState(_stateManager, _tableTurnManager, _player, card));
    }
}
