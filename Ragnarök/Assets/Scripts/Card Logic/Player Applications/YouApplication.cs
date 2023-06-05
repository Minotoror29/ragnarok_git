using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(menuName = "Player Application/You")]
public class YouApplication : PlayerApplication
{
    public override void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, PlayerEffectState state)
    {
        List<Player> targets = new()
        {
            sourcePlayer
        };

        Resolve(effectsManager, sourcePlayer, effect, targets, state);
    }

    //public override List<Player> Targets(Player source, Effect effect)
    //{
    //    List<Player> targets = new()
    //    {
    //        source
    //    };

    //    return targets;
    //}
}
