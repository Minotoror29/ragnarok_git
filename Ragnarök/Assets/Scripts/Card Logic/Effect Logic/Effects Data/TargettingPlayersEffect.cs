using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargettingPlayersEffect : EffectData
{
    public PlayerApplication application;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, TableTurnEffectState state)
    {
        application.DetermineTargets(effectsManager, sourcePlayer, this, state);
    }
    public abstract void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, TableTurnEffectState state);
}
