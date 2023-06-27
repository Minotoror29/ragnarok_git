using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplication : ScriptableObject
{
    public abstract void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state);
}
