using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TitlePointsApplication
{
    private List<Player> _players;

    public List<Player> Players { get { return _players; } }

    public TitlePointsApplication()
    {
        _players = new();
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public abstract void AssignPoints();
}
