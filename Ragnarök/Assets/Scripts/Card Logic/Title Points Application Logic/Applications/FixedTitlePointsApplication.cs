using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTitlePointsApplication : TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private int _value;

    public FixedTitlePointsApplication(TitlePointsId titlePointsId, int value)
    {
        _titlePointsId = titlePointsId;
        _value = value;
    }

    public override void AssignPoints()
    {
        foreach (Player player in Players)
        {
            player.TitlePoints[_titlePointsId] += _value;
            Debug.Log(player.PlayerName + " earned " + _value + " " + _titlePointsId.ToString() + " points");
        }
    }
}
