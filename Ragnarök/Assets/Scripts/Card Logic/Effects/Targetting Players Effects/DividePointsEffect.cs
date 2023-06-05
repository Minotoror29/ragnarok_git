using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Divide Points")]
public class DividePointsEffect : TargettingPlayersEffect
{
    public float value;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer, PlayerEffectState state)
    {
        application.DetermineTargets(effectsManager, sourcePlayer, this, state);
    }

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targetPlayers, PlayerEffectState state)
    {
        effectsManager.DividePlayerPoints(targetPlayers, value);
        state.ResolveEffect();
    }
}
