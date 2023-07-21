using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointsEffect : Effect
{
    private ValueApplication _valueApplication;
    private PlayerApplication _playerApplication;

    public AddPointsEffect(Player sourcePlayer, TableTurnEffectState state, ValueApplicationData valueApplicationData, PlayerApplicationData playerApplication) : base(sourcePlayer, state)
    {
        _valueApplication = valueApplicationData.Application(sourcePlayer, this, state);
        _playerApplication = playerApplication.Application(sourcePlayer, this, state);
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
        effectsManager.AddPointsToPlayers(_playerApplication.Targets, _valueApplication.Value);
    }
}
