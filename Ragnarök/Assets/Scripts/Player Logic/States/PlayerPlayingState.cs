using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayingState : PlayerState
{
    public PlayerPlayingState(PlayerStateManager stateManager, Player player) : base(stateManager, player)
    {
    }

    public override void Enter()
    {
        _player.NameText.color = Color.blue;
        _player.VCam.gameObject.SetActive(true);
    }

    public override void Exit()
    {
        _player.VCam.gameObject.SetActive(false);
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
