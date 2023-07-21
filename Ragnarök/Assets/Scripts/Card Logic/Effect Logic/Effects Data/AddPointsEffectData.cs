using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Points")]
public class AddPointsEffectData : EffectData
{
    public ValueApplicationData valueApplication;
    public PlayerApplicationData playerApplication;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new AddPointsEffect(sourcePlayer, state, valueApplication, playerApplication);
    }
}
