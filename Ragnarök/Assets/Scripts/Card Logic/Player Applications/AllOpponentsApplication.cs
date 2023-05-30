using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/All Opponents")]
public class AllOpponentsApplication : PlayerApplication
{
    public override List<Player> Targets(Player source, Effect effect)
    {
        return source.Opponents;
    }
}
