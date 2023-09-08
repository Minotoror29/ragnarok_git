using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Give")]
public class GiveEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public PlayerApplicationData playerApplication;

    public override Effect Effect(Card card, Player sourcePlayer)
    {
        return new GiveEffect(card, sourcePlayer, valueApplication, playerApplication);
    }
}
