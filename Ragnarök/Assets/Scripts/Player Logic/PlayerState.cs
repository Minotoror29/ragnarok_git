using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerStateManager _stateManager;
    protected Player _player;

    public PlayerState(PlayerStateManager stateManager, Player player)
    {
        _stateManager = stateManager;
        _player = player;
    }

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Select(TableTurnState tableTurnState);

    public virtual void CheckPoints(int points) { }
    public virtual void StartPlayerTurn() { }
    public virtual void EndPlayerTurn() { }
}
