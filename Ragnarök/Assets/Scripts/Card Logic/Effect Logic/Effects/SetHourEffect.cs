using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SetHourEffect : Effect
{
    private ValueApplication _valueApplication;

    public SetHourEffect(Player sourcePlayer, TableTurnEffectState state, ValueApplicationData valueApplicationData) : base(sourcePlayer, state)
    {
        _valueApplication = valueApplicationData.Application(sourcePlayer, this, state);
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
        _state.TableTurnManager.Clock.SetHour(_valueApplication.Value);
    }
}
