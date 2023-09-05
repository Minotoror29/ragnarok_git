using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHoursEffect : Effect
{
    private ValueApplication _valueApplication;

    public AddHoursEffect(Player sourcePlayer, TableTurnEffectState state, ValueApplicationData valueApplication) : base(sourcePlayer, state)
    {
        _valueApplication = valueApplication.Application(sourcePlayer, this, _state);
    }

    public override void Activate()
    {
        _valueApplication.DetermineValue();
    }

    public override void NextApplication()
    {
        base.NextApplication();

        _state.NextEffect();
    }

    public override void Resolve()
    {
        _state.TableTurnManager.Clock.AddHours(_valueApplication.Value);
    }
}
