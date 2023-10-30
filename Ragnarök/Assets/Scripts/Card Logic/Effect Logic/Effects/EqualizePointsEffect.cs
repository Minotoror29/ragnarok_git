using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqualizePointsEffect : Effect
{
    private TargetPlayersApplication _playerApplication;

    public EqualizePointsEffect(CardData card, Player sourcePlayer) : base(card, sourcePlayer)
    {
        _playerApplication = new TargetPlayersApplication(sourcePlayer, this, 1);
    }

    public override void SetEffectState(TableTurnEffectState state)
    {
        base.SetEffectState(state);

        _playerApplication.SetEffectState(state);
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
        _player.SetPoints(_playerApplication.Targets[0].Points);
    }
}
