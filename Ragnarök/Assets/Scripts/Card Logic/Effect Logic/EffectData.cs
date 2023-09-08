using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectData : ScriptableObject
{
    public string description;

    public abstract Effect Effect(Card card, Player sourcePlayer);
}
