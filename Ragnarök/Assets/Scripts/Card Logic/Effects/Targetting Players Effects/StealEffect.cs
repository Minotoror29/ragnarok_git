using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Steal")]
public class StealEffect : TargettingPlayersEffect
{
    public int points;

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, PlayerEffectState state)
    {
        effectsManager.StealPoints(sourcePlayer, targets, points);
        state.ResolveEffect();
    }
}
