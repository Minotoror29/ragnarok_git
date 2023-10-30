using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Divide Points")]
public class DividePointsEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public PlayerApplicationData playerApplication;

    public override Effect Effect(CardData card, Player sourcePlayer)
    {
        return new DividePointsEffect(card, sourcePlayer, valueApplication, playerApplication);
    }
}
