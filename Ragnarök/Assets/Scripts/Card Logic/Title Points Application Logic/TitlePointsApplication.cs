using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private int _value;

    private List<Player> _players;

    public TitlePointsApplication(TitlePointsId titlePointsId, int value)
    {
        _titlePointsId = titlePointsId;
        _value = value;

        _players = new();
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public void AssignPoints()
    {
        foreach (Player player in _players)
        {
            player.TitlePoints[_titlePointsId] += _value;
            Debug.Log(player.PlayerName + " earned " + _value + " " + _titlePointsId.ToString() + " points");
        }
    }
}
