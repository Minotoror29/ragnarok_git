using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Fixed")]
public class FixedValueApplication : ValueApplication
{
    public int value;

    public override void DetermineValue(EffectsManager effectsManager, Player sourcePlayer, AddHoursEffect effect, PlayerEffectState state)
    {
        effect.Resolve(effectsManager, value, state);
    }
}
