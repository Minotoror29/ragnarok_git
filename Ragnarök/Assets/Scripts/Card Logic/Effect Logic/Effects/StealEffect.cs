using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealEffect : Effect
{
    public PlayerApplication _playerApplication;
    public ValueApplication _valueApplication;

    public StealEffect(Player sourcePlayer, TableTurnEffectState state, PlayerApplicationData playerApplication, ValueApplicationData valueApplication) : base(sourcePlayer, state)
    {
        _playerApplication = playerApplication.Application(sourcePlayer, this, state);
        _valueApplication = valueApplication.Application(sourcePlayer, this, state);
    }

    public override void Activate()
    {
        _playerApplication.DetermineTargets();
    }

    public override void NextApplication()
    {
        base.NextApplication();

        if (_resolvedApplications == 1)
        {
            _valueApplication.DetermineValue();
        }
        else if (_resolvedApplications == 2)
        {
            _state.NextEffect();
        }
    }

    public override void Resolve(EffectsManager effectsManager)
    {
        effectsManager.StealPoints(_player, _playerApplication.Targets, _valueApplication.Value);
    }
}
