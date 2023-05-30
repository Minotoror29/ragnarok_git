using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/Target Players")]
public class TargetPlayersApplication : PlayerApplication
{
    public override List<Player> Targets(Player source, Effect effect)
    {
        List<Player> targets = new();

        return targets;
    }
}
