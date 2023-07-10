using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Skip Turn")]
public class SkipTurnEffect : TargettingPlayersEffect
{
    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer, List<Player> targets, PlayerEffectState state)
    {
        effectsManager.SkipTurn(targets);
        state.NextEffect();
    }
}
