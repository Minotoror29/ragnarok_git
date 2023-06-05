using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultState : PlayerState
{
    public PlayerDefaultState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        _player.SelectionManager.Enable(this);
    }

    public override void Exit()
    {
        _player.SelectionManager.Disable();
    }

    public override void SelectDeck(Card card)
    {
        _player.DrawCard(card);
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
    }

    public override void UpdateLogic()
    {
        _player.SelectionManager.UpdateLogic();
    }
}
