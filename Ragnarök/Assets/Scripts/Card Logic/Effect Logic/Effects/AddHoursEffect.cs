using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHoursEffect : Effect
{
    private ValueApplication _valueApplication;

    public AddHoursEffect(Card card, Player sourcePlayer, ValueApplicationData valueApplication) : base(card, sourcePlayer)
    {
        _valueApplication = valueApplication.Application(sourcePlayer, this);
    }

    public override void SetEffectState(TableTurnEffectState state)
    {
        base.SetEffectState(state);

        _valueApplication.SetEffectState(state);
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
