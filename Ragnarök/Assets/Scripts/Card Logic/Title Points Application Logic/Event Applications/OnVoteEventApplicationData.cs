using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event Application/On Vote")]
public class OnVoteEventApplicationData : EventApplicationData
{
    public override void AssignEvent(TableTurnCardState cardState, Action<Player, Player> AddPlayer)
    {
        //cardState.OnVote += AddPlayer;
    }

    public override void UnassignEvent(TableTurnCardState cardState, Action<Player, Player> AddPlayer)
    {
        //cardState.OnVote -= AddPlayer;
    }
}
