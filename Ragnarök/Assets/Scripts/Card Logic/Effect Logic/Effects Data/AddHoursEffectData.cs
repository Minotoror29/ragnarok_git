using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new AddHoursEffect(sourcePlayer, state, valueApplication);
    }

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, TableTurnEffectState state)
    {
        //valueApplication.DetermineValue(effectsManager, sourcePlayer, this, state);
    }

    public void Resolve(EffectsManager effectsManager, int value, TableTurnEffectState state)
    {
        effectsManager.AddHours(value);
        state.NextEffect();
    }
}
