using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(menuName = "Player Application/All Players")]
public class AllPlayersApplication : PlayerApplication
{
    public override void DetermineTargets(EffectsManager effectsManager, Player sourcePlayer, TargettingPlayersEffect effect, TableTurnEffectState state)
    {
        List<Player> targets = new()
        {
            sourcePlayer
        };

        foreach (Player player in sourcePlayer.Opponents)
        {
            targets.Add(player);
        }

        effect.Resolve(effectsManager, sourcePlayer, targets, state);
    }
}
