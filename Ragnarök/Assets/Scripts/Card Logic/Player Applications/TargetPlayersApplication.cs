using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/Target Players")]
public class TargetPlayersApplication : PlayerApplication
{
    public int playersToTarget;

    public override void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state)
    {
        //sourcePlayer.StateManager.ChangeState(new PlayerTargetState(effectsManager, sourcePlayer, effect, this, playersToTarget));
        state.EnterTargetState(new PlayerTargetState(effectsManager, sourcePlayer, effect, this, state, playersToTarget));
    }

    //public override List<Player> Targets(Player source, Effect effect)
    //{
    //    List<Player> targets = new();

    //    return targets;
    //}
}
