using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        _player.NameText.color = Color.red;
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
