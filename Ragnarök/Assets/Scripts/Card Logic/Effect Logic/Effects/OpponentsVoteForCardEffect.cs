using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentsVoteForCardEffect : Effect
{
    public OpponentsVoteForCardEffect(CardData card, Player player) : base(card, player)
    {
    }

    public override void Activate()
    {
        _state.NextEffect();
    }

    public override void Resolve()
    {
        _player.OpponentsVoteForCard = true;
    }
}
