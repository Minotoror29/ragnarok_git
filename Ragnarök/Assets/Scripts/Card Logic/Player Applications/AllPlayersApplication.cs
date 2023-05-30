using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/All Players")]
public class AllPlayersApplication : PlayerApplication
{
    public override List<Player> Targets(Player source, Effect effect)
    {
        List<Player> targets = new()
        {
            source
        };

        foreach (Player player in source.Opponents)
        {
            targets.Add(player);
        }

        return targets;
    }
}
