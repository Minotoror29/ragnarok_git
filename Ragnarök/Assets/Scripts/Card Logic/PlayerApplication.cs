using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplication : ScriptableObject
{
    public abstract List<Player> Targets(Player source, Effect effect);
}
