using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Points")]
public class AddPointsEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public PlayerApplicationData playerApplication;

    public override Effect Effect(CardData card, Player sourcePlayer)
    {
        return new AddPointsEffect(card, sourcePlayer, valueApplication, playerApplication);
    }
}
