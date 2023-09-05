using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualizePointsEffect : Effect
{
    private TargetPlayersApplication _playerApplication;

    public EqualizePointsEffect(Player sourcePlayer, TableTurnEffectState state) : base(sourcePlayer, state)
    {
        _playerApplication = new TargetPlayersApplication(sourcePlayer, this, state, 1);
    }

    public override void Activate()
    {
        _playerApplication.DetermineTargets();
    }

    public override void NextApplication()
    {
        base.NextApplication();

        _state.NextEffect();
    }

    public override void Resolve()
    {
        //effectsManager.EqualizePoints(_player, _playerApplication.Targets[0]);

        _player.SetPoints(_playerApplication.Targets[0].Points);
    }
}
