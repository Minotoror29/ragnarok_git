using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffect : Effect
{
    public ValueApplication valueApplication;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        valueApplication.DetermineValue(effectsManager, sourcePlayer, this, state);
    }

    public void Resolve(EffectsManager effectsManager, int value, PlayerEffectState state)
    {
        effectsManager.AddHours(value);
        state.ResolveEffect();
    }
}
