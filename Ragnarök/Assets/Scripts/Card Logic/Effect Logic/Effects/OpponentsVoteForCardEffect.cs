using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentsVoteForCardEffect : Effect
{
    public OpponentsVoteForCardEffect(Player player, TableTurnEffectState state) : base(player, state)
    {
    }

    public override void Activate()
    {
        _state.NextEffect();
    }

    public override void Resolve(EffectsManager effectsManager)
    {
        effectsManager.OpponentsVoteForCard(_player);
    }
}
