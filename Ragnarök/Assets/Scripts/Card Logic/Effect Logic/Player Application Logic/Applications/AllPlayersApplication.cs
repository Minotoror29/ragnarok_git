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

        Targets.Add(_player);

        foreach (Player player in _player.Opponents)
        {
            Targets.Add(player);
        }

        foreach (Player p in _effect.State.PlayersWhoVotedPlay)
        {
            ResponsiblePlayers.Add(p);
        }

        _effect.NextApplication();
    }
}
