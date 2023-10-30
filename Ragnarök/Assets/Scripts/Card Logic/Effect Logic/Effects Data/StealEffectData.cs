using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Steal")]
public class StealEffectData : EffectData
{
    public PlayerApplicationData playerApplication;
    public ValueApplicationData valueApplication;

    public override Effect Effect(CardData card, Player sourcePlayer)
    {
        return new StealEffect(card, sourcePlayer, playerApplication, valueApplication);
    }
}
