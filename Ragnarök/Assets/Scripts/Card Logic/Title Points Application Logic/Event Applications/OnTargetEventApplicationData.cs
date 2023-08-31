using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Application/On Target")]
public class OnTargetEventApplicationData : EventApplicationData
{
    public override void AssignEvent(TableTurnCardState cardState, Action<Player, Player> AddPlayer)
    {
        cardState.OnTarget += AddPlayer;
    }

    public override void UnassignEvent(TableTurnCardState cardState, Action<Player, Player> AddPlayer)
    {
        cardState.OnTarget -= AddPlayer;
    }
}
