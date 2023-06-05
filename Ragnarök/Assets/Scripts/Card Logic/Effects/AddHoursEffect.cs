using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffect : Effect
{
    public int hours;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        //Resolve(effectsManager, sourcePlayer);
        effectsManager.AddHours(hours);
        state.ResolveEffect();
    }

    //public override void Resolve(EffectsManager effectsManager, Player sourcePlayer)
    //{
    //    effectsManager.AddHours(hours);
    //}
}
