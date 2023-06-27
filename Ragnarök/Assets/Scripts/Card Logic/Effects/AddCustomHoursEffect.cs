using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Custom Hours")]
public class AddCustomHoursEffect : Effect
{
    public CustomValueApplication valueApplication;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        valueApplication.DetermineValue(effectsManager, sourcePlayer, this, state);
    }

    public void Resolve(EffectsManager effectsManager, Player sourcePlayer, int value, PlayerEffectState state)
    {
        effectsManager.AddHours(value);
        effectsManager.AddPointsToPlayers(new List<Player>() { sourcePlayer }, value);
        state.ResolveEffect();
    }
}
