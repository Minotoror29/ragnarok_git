using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Divide Points")]
public class DividePointsEffect : TargettingPlayersEffect
{
    public float value;

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targetPlayers, TableTurnEffectState state)
    {
        effectsManager.DividePlayerPoints(targetPlayers, value);
        state.NextEffect();
    }
}
