using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Equalize Points")]
public class EqualizePointsEffectData : EffectData
{
    public override Effect Effect(Card card, Player sourcePlayer)
    {
        return new EqualizePointsEffect(card, sourcePlayer);
    }
}
