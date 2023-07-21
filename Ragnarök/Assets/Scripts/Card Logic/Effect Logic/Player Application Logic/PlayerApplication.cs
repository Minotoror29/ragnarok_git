using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerApplication
{
    protected Player _player;
    protected Effect _effect;

    protected List<Player> _targets;
    public List<Player> Targets { get { return _targets; } }

    public PlayerApplication(Player player, Effect effect)
    {
        _player = player;
        _effect = effect;
    }

    public virtual void DetermineTargets()
    {
        _targets = new();
    }
}
