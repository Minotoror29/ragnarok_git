using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Equalize Points")]
public class EqualizePointsEffectData : EffectData
{
    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new EqualizePointsEffect(sourcePlayer, state);
    }
}
