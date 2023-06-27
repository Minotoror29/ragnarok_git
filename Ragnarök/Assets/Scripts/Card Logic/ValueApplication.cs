using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplication : ScriptableObject
{
    public abstract void DetermineValue(EffectsManager effectsManager, Player sourcePlayer, AddHoursEffect effect, PlayerEffectState state);
}
