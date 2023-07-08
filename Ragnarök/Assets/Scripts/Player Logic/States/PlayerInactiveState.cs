using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInactiveState : PlayerState
{
    private StateManager _stateManager;

    public PlayerInactiveState(Player player) : base (player)
    {
    }

    public override void Enter()
    {
        _player.NameText.color = Color.white;
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }

    public override void StartPlayerTurn()
    {
        base.StartPlayerTurn();

        _stateManager.ChangeState(new PlayerPlayingState(_player));
    }

    public override void CheckPoints(int points)
    {
        base.CheckPoints(points);

        if (points == 0)
        {
            _stateManager.ChangeState(new PlayerDeadState(_player));
        }
    }
}
