using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Set Hour")]
public class SetHourEffect : Effect
{
    public int hour;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer)
    {
        Resolve(effectsManager, sourcePlayer);
    }

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer)
    {
        effectsManager.SetHour(hour);
    }
}
