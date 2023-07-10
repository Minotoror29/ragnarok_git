using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHoursEffect : Effect
{
    private ValueApplication _valueApplication;

    public AddHoursEffect(Player sourcePlayer, PlayerEffectState state, ValueApplicationData valueApplicationData) : base(sourcePlayer, state)
    {
        _player = sourcePlayer;
        _valueApplication = valueApplicationData.ValueApplication(_player, this, state);
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

    public override void Resolve(EffectsManager effectsManager)
    {
        effectsManager.AddHours(_valueApplication.ReturnValue());
    }
}
