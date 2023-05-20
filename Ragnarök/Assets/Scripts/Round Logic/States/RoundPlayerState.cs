using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundPlayerState : State
{
    private RoundManager _roundManager;
    private Player _player;

    public RoundPlayerState(RoundManager roundManager, Player player)
    {
        _roundManager = roundManager;
        _player = player;
    }

    public override void Enter()
    {
        _player.StartTurn();
    }

    public override void Exit()
    {
        _player.EndTurn();
    }

    public override void UpdateLogic()
    {
        
    }
}
