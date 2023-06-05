using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplication : ScriptableObject
{
    public abstract void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state);
    public void Resolve(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, List<Player> targetedPlayers, PlayerEffectState state)
    {
        effect.Resolve(effectsManager, sourcePlayer, targetedPlayers, state);
    }

    //public abstract List<Player> Targets(Player source, Effect effect);
}
