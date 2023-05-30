using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Add Points")]
public class AddPointsEffect : Effect
{
    public int points;
    public PlayerApplication playerApplication;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer)
    {
        Resolve(effectsManager, sourcePlayer);
    }

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer)
    {
        effectsManager.AddPointsToPlayers(playerApplication.Targets(sourcePlayer, this), points);
    }
}
