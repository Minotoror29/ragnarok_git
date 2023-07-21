using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Empty", order = 0)]
public class EmptyEffectData : EffectData
{
    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new EmptyEffect(sourcePlayer, state);
    }
}
