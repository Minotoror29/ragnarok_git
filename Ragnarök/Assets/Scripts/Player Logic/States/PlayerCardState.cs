using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCardState : PlayerState
{
    public PlayerCardState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        _player.DisplayCardCanvas(true);
    }

    public override void Exit()
    {
        _player.DisplayCardCanvas(false);
    }

    public override void UpdateLogic()
    {
        
    }
}
