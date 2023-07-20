using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectData : ScriptableObject
{
    public string description;

    public virtual Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return null;
    }

    public abstract void Activate(EffectsManager effectsManager, Player sourcePlayer, TableTurnEffectState state);
}
