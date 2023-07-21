using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Skip Turn")]
public class SkipTurnEffectData : EffectData
{
    public PlayerApplicationData playerApplication;

    public override Effect Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        return new SkipTurnEffect(sourcePlayer, state, playerApplication);
    }
}
