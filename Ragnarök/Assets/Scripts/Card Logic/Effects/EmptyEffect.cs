using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Empty", order = 0)]
public class EmptyEffect : Effect
{
    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        state.ResolveEffect();
    }
}
