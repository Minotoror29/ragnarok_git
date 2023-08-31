using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTitlePointsApplication : TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private int _value;

    public FixedTitlePointsApplication(TableTurnCardState cardState, TitlePointsId titlePointsId, int value) : base(cardState)
    {
        _titlePointsId = titlePointsId;
        _value = value;

        cardState.OnVote += AddPlayer;
    }

    public override void AssignPoints()
    {
        foreach (Player player in Players)
        {
            player.TitlePoints[_titlePointsId] += _value;
            Debug.Log(player.PlayerName + " earned " + _value + " " + _titlePointsId.ToString() + " points");
        }

        CardState.OnVote -= AddPlayer;
    }
}
