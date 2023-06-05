using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(menuName = "Player Application/All Players")]
public class AllPlayersApplication : PlayerApplication
{
    public override void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state)
    {
        List<Player> targets = new()
        {
            sourcePlayer
        };

        foreach (Player player in sourcePlayer.Opponents)
        {
            targets.Add(player);
        }

        Resolve(effectsManager, sourcePlayer, effect, targets, state);
    }

    //public override List<Player> Targets(Player source, Effect effect)
    //{
    //    List<Player> targets = new()
    //    {
    //        source
    //    };

    //    foreach (Player player in source.Opponents)
    //    {
    //        targets.Add(player);
    //    }

    //    return targets;
    //}
}
