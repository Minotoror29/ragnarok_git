using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Points")]
public class AddPointsEffect : Effect
{
    public int points;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer)
    {
        effectsManager.AddPointsToPlayer(sourcePlayer, points);
    }
}
