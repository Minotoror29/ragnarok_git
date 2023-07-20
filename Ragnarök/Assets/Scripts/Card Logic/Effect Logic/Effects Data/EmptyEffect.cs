using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Empty", order = 0)]
public class EmptyEffect : EffectData
{
    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, TableTurnEffectState state)
    {
        state.NextEffect();
    }
}
