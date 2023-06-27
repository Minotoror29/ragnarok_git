using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Custom")]
public class CustomValueApplication : ValueApplication
{
    public bool add;

    public override void DetermineValue(EffectsManager effectsManager, Player sourcePlayer, AddHoursEffect effect, PlayerEffectState state)
    {
        state.EnterSubState(new PlayerValueState(effectsManager, sourcePlayer, effect, this, state));
    }
}
