using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Points")]
public class AddPointsEffect : TargettingPlayersEffect
{
    public int points;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        application.DetermineTargets(effectsManager, sourcePlayer, this, state);
    }

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targetPlayers, PlayerEffectState state)
    {
        effectsManager.AddPointsToPlayers(targetPlayers, points);
        state.ResolveEffect();
    }
}
