using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffect : Effect
{
    public int hours;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        effectsManager.AddHours(hours);
        state.ResolveEffect();
    }
}
