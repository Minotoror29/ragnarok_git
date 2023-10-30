using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Opponents Vote For Next Card")]
public class OpponentsVoteForCardEffectData : EffectData
{
    public override Effect Effect(CardData card, Player sourcePlayer)
    {
        return new OpponentsVoteForCardEffect(card, sourcePlayer);
    }
}
