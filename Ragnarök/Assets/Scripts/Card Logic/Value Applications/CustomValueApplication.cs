using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Custom")]
public class CustomValueApplication : ScriptableObject
{
    public bool add;

    public void DetermineValue(EffectsManager effectsManager, Player sourcePlayer, AddCustomHoursEffect effect, PlayerEffectState state)
    {
        state.EnterSubState(new PlayerValueState(effectsManager, sourcePlayer, effect, this, state));
    }
}
