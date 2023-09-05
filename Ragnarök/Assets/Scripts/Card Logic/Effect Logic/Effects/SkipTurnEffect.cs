using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTurnEffect : Effect
{
    private PlayerApplication _playerApplication;

    public SkipTurnEffect(Player sourcePlayer, TableTurnEffectState state, PlayerApplicationData playerApplication) : base(sourcePlayer, state)
    {
        _playerApplication = playerApplication.Application(sourcePlayer, this, state);
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
