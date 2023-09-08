using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

[CreateAssetMenu(menuName = "Player Application/You")]
public class YouApplicationData : PlayerApplicationData
{
    public override PlayerApplication Application(Player player, Effect effect)
    {
        return new YouApplication(player, effect);
    }
}
