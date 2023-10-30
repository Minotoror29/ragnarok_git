using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public override Effect Effect(CardData card, Player sourcePlayer)
    {
        return new AddHoursEffect(card, sourcePlayer, valueApplication);
    }
}
