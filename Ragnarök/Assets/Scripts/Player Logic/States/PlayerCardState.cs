using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardState : PlayerState
{
    private Card _card;

    public PlayerCardState(Player player, Card card) : base(player)
    {
        _card = card;
    }

    public override void Enter()
    {
        _player.CardCanvas.gameObject.SetActive(true);
        _player.CardDisplay.Initialize(_card);
    }

    public override void Exit()
    {
        _player.CardCanvas.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
        
    }
}
