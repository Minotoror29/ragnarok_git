using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Custom Hours")]
public class AddCustomHoursEffect : EffectData
{
    public CustomValueApplicationData valueApplication;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, TableTurnEffectState state)
    {
        //valueApplication.DetermineValue(effectsManager, sourcePlayer, this, state);
    }

    public void Resolve(EffectsManager effectsManager, Player sourcePlayer, int value, TableTurnEffectState state)
    {
        effectsManager.AddHours(value);
        effectsManager.AddPointsToPlayers(new List<Player>() { sourcePlayer }, value);
        state.NextEffect();
    }
}
