using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnCardState : TableTurnState
{
    private Player _player;

    private Card _card;

    public TableTurnCardState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card) : base(stateManager, tableTurnManager)
    {
        _player = player;

        _card = card;
    }

    public override void Enter()
    {
        _tableTurnManager.CardDisplay.gameObject.SetActive(true);
        _tableTurnManager.CardDisplay.SetCard(_player, _card, _player.OpponentsVoteForCard, this);
    }

    public override void Exit()
    {
        _tableTurnManager.CardDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public void PlayCard(EffectsManager effectsManager, Card card, bool opponentsVote)
    {
        _stateManager.ChangeState(new TableTurnEffectState(_stateManager, _tableTurnManager, _player, card, card.effect1, card.effect2, effectsManager, opponentsVote));
    }

    public void DiscardCard()
    {
        _player.EndPlayerTurn();
        _tableTurnManager.ActivePlayers.Remove(_player);
        _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager));
    }
}
