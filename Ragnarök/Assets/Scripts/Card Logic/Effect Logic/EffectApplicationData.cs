using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectApplicationData : ScriptableObject
{
    public abstract EffectApplication Application(Player player, Effect effect, TableTurnEffectState state);
}
