using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomValueRelativeTitlePointsApplication : TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private List<int> _values;

    public CustomValueRelativeTitlePointsApplication(TableTurnCardState cardState, TitlePointsId titlePointsId) : base(cardState)
    {
        _titlePointsId = titlePointsId;
        _values = new();

        cardState.OnValue += AddPlayerAndValue;
    }

    private void AddPlayerAndValue(Player player, int value)
    {
        AddPlayer(player);
        _values.Add(value);
    }

    public override void AssignPoints()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].TitlePoints[_titlePointsId] += _values[i];
            Debug.Log(Players[i].PlayerName + " earned " + _values[i] + " " + _titlePointsId.ToString() + " points");
        }
    }
}
