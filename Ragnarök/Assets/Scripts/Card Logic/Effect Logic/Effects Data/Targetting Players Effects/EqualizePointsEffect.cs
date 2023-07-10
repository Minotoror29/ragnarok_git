using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Equalize Points")]
public class EqualizePointsEffect : TargettingPlayersEffect
{
    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, PlayerEffectState state)
    {
        effectsManager.EqualizePoints(sourcePlayer, targets[0]);
        state.NextEffect();
    }
}
