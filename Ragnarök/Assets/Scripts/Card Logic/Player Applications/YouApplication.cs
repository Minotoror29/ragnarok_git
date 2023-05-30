using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/You")]
public class YouApplication : PlayerApplication
{
    public override List<Player> Targets(Player source, Effect effect)
    {
        List<Player> targets = new()
        {
            source
        };

        return targets;
    }
}
