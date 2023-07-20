using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplication
{
    protected Player _player;
    protected Effect _effect;
    protected TableTurnEffectState _state;

    protected int _value;

    public ValueApplication(Player player, Effect effect, TableTurnEffectState state)
    {
        _player = player;
        _effect = effect;
        _state = state;
    }

    public abstract void DetermineValue();
    public int ReturnValue()
    {
        return _value;
    }
}
