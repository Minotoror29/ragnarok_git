using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public override Effect Effect(Player sourcePlayer, PlayerEffectState state)
    {
        return new AddHoursEffect(sourcePlayer, state, valueApplication);
    }

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        //valueApplication.DetermineValue(effectsManager, sourcePlayer, this, state);
    }

    public void Resolve(EffectsManager effectsManager, int value, PlayerEffectState state)
    {
        effectsManager.AddHours(value);
        state.NextEffect();
    }
}
