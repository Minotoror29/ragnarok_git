using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInactiveState : PlayerState
{
    public PlayerInactiveState(PlayerStateManager stateManager, Player player) : base(stateManager, player)
    {
    }

    public override void Enter()
    {
        _player.NameText.color = Color.white;
        _player.PlayerOverlay.SetColor(Color.white);
    }

    public override void Exit()
    {
    }

    public override void StartPlayerTurn()
    {
        base.StartPlayerTurn();

        _stateManager.ChangeState(new PlayerPlayingState(_stateManager, _player));
    }

    public override void CheckPoints(int points)
    {
        base.CheckPoints(points);

        if (points == 0)
        {
            _stateManager.ChangeState(new PlayerDeadState(_stateManager, _player));
        }
    }

    public override void Select(TableTurnState tableTurnState)
    {
        tableTurnState.SelectPlayer(_player);
    }

    public override void TargetVote()
    {
        _player.PlayerOverlay.TargetVote();
    }
}
