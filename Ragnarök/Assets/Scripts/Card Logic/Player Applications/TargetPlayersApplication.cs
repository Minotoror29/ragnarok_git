using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/Target Players")]
public class TargetPlayersApplication : PlayerApplication
{
    public int playersToTarget;

    public override void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state)
    {
        state.EnterTargetState(new PlayerTargetState(effectsManager, sourcePlayer, effect, this, state, playersToTarget));
    }
}
