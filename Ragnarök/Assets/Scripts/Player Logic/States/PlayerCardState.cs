using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardState : PlayerState
{
    private MatchManager _matchManager;

    private Card _card;

    public PlayerCardState(StateManager stateManager, MatchManager matchManager, Player player, Card card) : base(stateManager, player)
    {
        _matchManager = matchManager;
        _card = card;
    }

    public override void Enter()
    {
        _player.CardCanvas.gameObject.SetActive(true);
        _player.CardDisplay.SetCard(_player, _card, _player.opponentsVoteForCard, this);
    }

    public override void Exit()
    {
        _player.CardCanvas.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public void PlayCard(EffectsManager effectsManager, Card card)
    {
        _stateManager.ChangeState(new PlayerEffectState(_stateManager, _matchManager, _player, card.effect1, card.effect2, effectsManager));
    }

    public void DiscardCard()
    {
        _player.EndPlayerTurn();
        _stateManager.ChangeState(new CheckEndRoundConditionsState(_stateManager, _matchManager, _player));
    }
}
