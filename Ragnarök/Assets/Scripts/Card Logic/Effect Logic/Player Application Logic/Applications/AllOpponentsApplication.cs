using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllOpponentsApplication : PlayerApplication
{
    public AllOpponentsApplication(Player player, Effect effect) : base(player, effect)
    {
    }

    public override void DetermineTargets()
    {
        base.DetermineTargets();

        foreach (Player player in _player.Opponents)
        {
            _targets.Add(player);
        }
        _effect.NextApplication();
    }
}
