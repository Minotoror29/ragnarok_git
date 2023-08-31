using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TitlePointsApplication
{
    private TableTurnCardState _cardState;
    private EventApplicationData _eventApplication;

    private List<Player> _players;

    public List<Player> Players { get { return _players; } }

    public TitlePointsApplication(TableTurnCardState cardState, EventApplicationData eventApplicationData)
    {
        _cardState = cardState;
        _eventApplication = eventApplicationData;
        eventApplicationData.AssignEvent(cardState, AddPlayer);

        _players = new();
    }

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public virtual void AssignPoints()
    {
        _eventApplication.UnassignEvent(_cardState, AddPlayer);
    }
}
