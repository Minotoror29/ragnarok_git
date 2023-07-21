using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Set Hour")]
public class SetHourEffectData : EffectData
{
    public ValueApplicationData valueApplication;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new SetHourEffect(sourcePlayer, state, valueApplication);
    }
}
