using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Skip Turn")]
public class SkipTurnEffectData : EffectData
{
    public PlayerApplicationData playerApplication;

    public override Effect Effect(Card card, Player sourcePlayer)
    {
        return new SkipTurnEffect(card, sourcePlayer, playerApplication);
    }
}
