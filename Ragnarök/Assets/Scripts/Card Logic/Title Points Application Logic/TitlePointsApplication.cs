using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TitlePointsApplication
{
    private TableTurnCardState _cardState;

    private List<Player> _players;

    public TableTurnCardState CardState { get { return _cardState; } }
    public List<Player> Players { get { return _players; } }

    public TitlePointsApplication(TableTurnCardState cardState)
    {
        _cardState = cardState;

        _players = new();
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public abstract void AssignPoints();
}
