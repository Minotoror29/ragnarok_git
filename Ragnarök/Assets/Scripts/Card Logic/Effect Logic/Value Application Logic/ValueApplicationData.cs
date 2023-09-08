using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplicationData : ScriptableObject
{
    public abstract ValueApplication Application(Player player, Effect effect);
}
