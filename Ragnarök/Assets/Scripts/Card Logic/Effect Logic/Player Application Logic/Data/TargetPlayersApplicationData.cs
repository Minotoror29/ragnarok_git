using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Application/Target Players")]
public class TargetPlayersApplicationData : PlayerApplicationData
{
    public int playersToTarget;

    public override PlayerApplication Application(Player player, Effect effect, TableTurnEffectState state)
    {
        return new TargetPlayersApplication(player, effect, state, playersToTarget);
    }
}
