using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Hours")]
public class AddHoursEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new AddHoursEffect(sourcePlayer, state, valueApplication);
    }
}
