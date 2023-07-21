using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Opponents Vote For Next Card")]
public class OpponentsVoteForCardEffectData : EffectData
{
    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new OpponentsVoteForCardEffect(sourcePlayer, state);
    }
}
