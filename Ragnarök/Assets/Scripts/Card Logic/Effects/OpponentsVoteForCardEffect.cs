using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Opponents Vote For Next Card")]
public class OpponentsVoteForCardEffect : Effect
{
    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        effectsManager.OpponentsVoteForCard(sourcePlayer);
        state.ResolveEffect();
    }
}
