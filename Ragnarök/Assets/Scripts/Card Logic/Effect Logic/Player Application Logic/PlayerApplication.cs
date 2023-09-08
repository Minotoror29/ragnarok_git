using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplication
{
    protected Player _player;
    protected Effect _effect;
    protected TableTurnEffectState _state;

    private List<Player> _targets;

    private List<Player> _responsiblePlayers;

    public List<Player> Targets { get { return _targets; } }
    public List<Player> ResponsiblePlayers { get { return _responsiblePlayers; } }

    public PlayerApplication(Player player, Effect effect)
    {
        _player = player;
        _effect = effect;
        _responsiblePlayers = new();
    }

    public void SetEffectState(TableTurnEffectState state)
    {
        _state = state;
    }

    public virtual void DetermineTargets()
    {
        _targets = new();
    }
}
