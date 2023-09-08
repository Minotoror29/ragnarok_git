using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ValueApplication
{
    protected Player _player;
    protected Effect _effect;
    protected TableTurnEffectState _state;

    protected int _value;

    public int Value { get { return _value; } }

    public ValueApplication(Player player, Effect effect)
    {
        _player = player;
        _effect = effect;
    }

    public void SetEffectState(TableTurnEffectState state)
    {
        _state = state;
    }

    public abstract void DetermineValue();
}
