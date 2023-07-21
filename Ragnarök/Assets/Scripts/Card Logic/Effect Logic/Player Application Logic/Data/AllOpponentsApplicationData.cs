using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/All Opponents")]
public class AllOpponentsApplicationData : PlayerApplicationData
{
    public override PlayerApplication Application(Player player, Effect effect, TableTurnEffectState state)
    {
        return new AllOpponentsApplication(player, effect);
    }
}
