using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Doctrine")]
public class DoctrineEffectData : EffectData
{
    public bool add;

    public override Effect Effect(CardData card, Player sourcePlayer)
    {
        return new DoctrineEffect(card, sourcePlayer, add);
    }
}
