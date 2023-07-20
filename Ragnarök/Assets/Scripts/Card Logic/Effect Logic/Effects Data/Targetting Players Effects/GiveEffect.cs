using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Give")]
public class GiveEffect : TargettingPlayersEffect
{
    public int points;

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, TableTurnEffectState state)
    {
        effectsManager.GivePoints(sourcePlayer, targets, points);
        state.NextEffect();
    }
}
