using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect
{
    protected EffectsManager _effectsManager;
    protected Player _player;
    protected TableTurnEffectState _state;

    protected int _resolvedApplications;

    public Effect(Player player, TableTurnEffectState state)
    {
        _player = player;
        _state = state;

        _resolvedApplications = 0;
    }

    public abstract void Activate();
    public virtual void NextApplication()
    {
        _resolvedApplications++;
    }
    public abstract void Resolve(EffectsManager effectsManager);
}
