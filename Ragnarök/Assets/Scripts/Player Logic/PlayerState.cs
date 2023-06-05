using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player _player;
    protected SelectionManager _selectionManager;

    public PlayerState(Player player)
    {
        _player = player;
    }

    public abstract void SelectDeck(Card card);

    public abstract void SelectPlayer(Player selectedPlayer);
}
