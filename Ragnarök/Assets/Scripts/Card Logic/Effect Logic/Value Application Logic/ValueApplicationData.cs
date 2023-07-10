using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplicationData : ScriptableObject
{
    public abstract ValueApplication ValueApplication(Player player, Effect effect, PlayerEffectState state);
}
