using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Steal")]
public class StealEffectData : EffectData
{
    public PlayerApplicationData playerApplication;
    public ValueApplicationData valueApplication;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new StealEffect(sourcePlayer, state, playerApplication, valueApplication);
    }
}
