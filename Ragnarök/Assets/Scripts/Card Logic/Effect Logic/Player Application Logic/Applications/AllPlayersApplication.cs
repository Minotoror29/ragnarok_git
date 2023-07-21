using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayersApplication : PlayerApplication
{
    public AllPlayersApplication(Player player, Effect effect) : base(player, effect)
    {
    }

    public override void DetermineTargets()
    {
        base.DetermineTargets();

        _targets.Add(_player);

        foreach (Player player in _player.Opponents)
        {
            _targets.Add(player);
        }

        _effect.NextApplication();
    }
}
