using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effect/Divide Points")]
public class DividePointsEffect : Effect
{
    public float value;

    public override void Activate(EffectsManager effectsManager, Player sourcePlayer)
    {
        Resolve(effectsManager, sourcePlayer);
    }

    public override void Resolve(EffectsManager effectsManager, Player sourcePlayer)
    {
        effectsManager.DividePlayerPoints(sourcePlayer, value);
    }
}
