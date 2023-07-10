using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Set Hour")]
public class SetHourEffect : EffectData
{
    public int hour;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        effectsManager.SetHour(hour);
        state.NextEffect();
    }
}
