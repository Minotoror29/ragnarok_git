using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargettingPlayersEffect : Effect
{
    public PlayerApplication application;

    public abstract void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, PlayerEffectState state);
}
