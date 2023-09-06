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
            Targets.Add(player);
        }

        foreach (Player p in _effect.State.PlayersWhoVotedYes)
        {
            ResponsiblePlayers.Add(p);
        }

        _effect.NextApplication();
    }
}
