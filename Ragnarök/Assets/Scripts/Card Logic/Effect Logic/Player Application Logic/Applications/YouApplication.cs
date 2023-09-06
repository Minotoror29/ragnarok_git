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

        Targets.Add(_player);

        foreach (Player p in _effect.State.PlayersWhoVotedYes)
        {
            ResponsiblePlayers.Add(p);
        }

        _effect.NextApplication();
    }
}
