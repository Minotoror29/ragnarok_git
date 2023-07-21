using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouApplication : PlayerApplication
{
    public YouApplication(Player sourcePlayer, Effect effect) : base(sourcePlayer, effect)
    {
    }

    public override void DetermineTargets()
    {
        base.DetermineTargets();

        _targets.Add(_player);

        _effect.NextApplication();
    }
}
