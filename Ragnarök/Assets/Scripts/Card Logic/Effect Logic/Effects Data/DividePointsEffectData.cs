using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Divide Points")]
public class DividePointsEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public PlayerApplicationData playerApplication;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new DividePointsEffect(sourcePlayer, state, valueApplication, playerApplication);
    }
}
