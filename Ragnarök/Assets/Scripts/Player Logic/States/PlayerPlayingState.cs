using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayingState : PlayerState
{
    public PlayerPlayingState(StateManager stateManager, Player player) : base(stateManager, player)
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
            _stateManager.ChangeState(new PlayerDeadState(_stateManager, _player));
        }
    }

    public override void EndPlayerTurn()
    {
        base.EndPlayerTurn();

        _stateManager.ChangeState(new PlayerInactiveState(_stateManager, _player));
    }
}
