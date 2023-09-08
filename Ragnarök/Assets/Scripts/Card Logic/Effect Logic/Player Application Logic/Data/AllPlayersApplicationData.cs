using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(menuName = "Player Application/All Players")]
public class AllPlayersApplicationData : PlayerApplicationData
{
    public override PlayerApplication Application(Player player, Effect effect)
    {
        return new AllPlayersApplication(player, effect);
    }
}
