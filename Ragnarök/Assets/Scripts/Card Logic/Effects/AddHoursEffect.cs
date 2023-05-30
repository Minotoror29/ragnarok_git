using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffect : Effect
{
    public int hours;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer)
    {
        Resolve(effectsManager, sourcePlayer);
    }

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer)
    {
        effectsManager.AddHours(hours);
    }
}
