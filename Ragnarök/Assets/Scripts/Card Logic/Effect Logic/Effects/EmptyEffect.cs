using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyEffect : Effect
{
    public EmptyEffect(Player sourcePlayer, TableTurnEffectState state) : base(sourcePlayer, state)
    {
    }

    public override void Activate()
    {
        _state.NextEffect();
    }

    public override void Resolve()
    {
        
    }
}
