using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayingState : PlayerState
{
    private StateManager _stateManager;

    public PlayerPlayingState(Player player) : base(player)
    {
    }

    public override void Enter()
    {
        _player.NameText.color = Color.blue;
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }

    public override void CheckPoints(int points)
    {
        base.CheckPoints(points);

        if (points == 0)
        {
            _stateManager.ChangeState(new PlayerDeadState(_player));
        }
    }

    public override void EndPlayerTurn()
    {
        base.EndPlayerTurn();

        _stateManager.ChangeState(new PlayerInactiveState(_player));
    }
}
