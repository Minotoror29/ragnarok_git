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
        _player.SelectionManager.Enable();
    }

    public override void Exit()
    {
        _player.SelectionManager.Disable();
    }

    public override void UpdateLogic()
    {
        _player.SelectionManager.UpdateLogic();
    }
}
