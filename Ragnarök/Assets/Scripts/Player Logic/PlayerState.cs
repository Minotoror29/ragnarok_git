using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : State
{
    protected Player _player;
    protected SelectionManager _selectionManager;

    public PlayerState(StateManager stateManager, Player player) : base(stateManager)
    {
        _player = player;
    }

    public virtual void SelectDeck(Card card) { }

    public virtual void SelectPlayer(Player selectedPlayer) { }

    public virtual void CheckPoints(int points) { }
    public virtual void StartPlayerTurn() { }
    public virtual void EndPlayerTurn() { }
}
