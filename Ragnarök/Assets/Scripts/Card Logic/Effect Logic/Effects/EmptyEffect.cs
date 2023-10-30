using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyEffect : Effect
{
    public EmptyEffect(CardData card, Player sourcePlayer) : base(card, sourcePlayer)
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
