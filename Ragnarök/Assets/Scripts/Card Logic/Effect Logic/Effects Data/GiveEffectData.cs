using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Give")]
public class GiveEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public PlayerApplicationData playerApplication;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new GiveEffect(sourcePlayer, state, valueApplication, playerApplication);
    }
}
