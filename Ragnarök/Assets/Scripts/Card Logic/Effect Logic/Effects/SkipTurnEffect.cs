using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTurnEffect : Effect
{
    private PlayerApplication _playerApplication;

    public SkipTurnEffect(Card card, Player sourcePlayer, PlayerApplicationData playerApplication) : base(card, sourcePlayer)
    {
        _playerApplication = playerApplication.Application(sourcePlayer, this);
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
        foreach (Player target in _playerApplication.Targets)
        {
            target.MustSkipNextTurn = true;
        }
    }
}
