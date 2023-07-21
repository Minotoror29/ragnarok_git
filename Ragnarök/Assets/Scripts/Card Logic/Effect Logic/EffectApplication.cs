using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectApplication
{
    protected Player _player;
    protected Effect _effect;

    public EffectApplication(Player player, Effect effect)
    {
        _player = player;
        _effect = effect;
    }

    public abstract void Determine();
}
