using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplicationData : ScriptableObject
{
    public abstract PlayerApplication Application(Player player, Effect effect);
}
