using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/All Opponents")]
public class AllOpponentsApplication : PlayerApplication
{
    public override void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state)
    {
        Resolve(effectsManager, sourcePlayer, effect, sourcePlayer.Opponents, state);
    }

    //public override List<Player> Targets(Player source, Effect effect)
    //{
    //    return source.Opponents;
    //}
}
