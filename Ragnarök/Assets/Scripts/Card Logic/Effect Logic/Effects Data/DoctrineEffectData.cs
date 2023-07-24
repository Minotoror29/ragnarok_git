using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Doctrine")]
public class DoctrineEffectData : EffectData
{
    public bool add;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new DoctrineEffect(sourcePlayer, state, add);
    }
}
