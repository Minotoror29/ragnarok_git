using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Empty", order = 0)]
public class EmptyEffectData : EffectData
{
    public override Effect Effect(Card card, Player sourcePlayer)
    {
        return new EmptyEffect(card, sourcePlayer);
    }
}
