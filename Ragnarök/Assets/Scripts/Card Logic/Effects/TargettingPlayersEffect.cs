using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargettingPlayersEffect : Effect
{
    public PlayerApplication application;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        application.DetermineTargets(effectsManager, sourcePlayer, this, state);
    }
    public abstract void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, PlayerEffectState state);
}
