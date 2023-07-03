using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string description;

    public abstract void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state);
}
