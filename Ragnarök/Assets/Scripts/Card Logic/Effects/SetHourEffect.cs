using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Set Hour")]
public class SetHourEffect : Effect
{
    public int hour;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        //Resolve(effectsManager, sourcePlayer);
        effectsManager.SetHour(hour);
        state.ResolveEffect();
    }

    //public override void Resolve(EffectsManager effectsManager, Player sourcePlayer)
    //{
    //    effectsManager.SetHour(hour);
    //}
}
