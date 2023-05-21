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
        _player.EnableSelection();
    }

    public override void Exit()
    {
        _player.DisableSelection();
    }

    public override void UpdateLogic()
    {
        _player.UpdateSelection();
    }
}
