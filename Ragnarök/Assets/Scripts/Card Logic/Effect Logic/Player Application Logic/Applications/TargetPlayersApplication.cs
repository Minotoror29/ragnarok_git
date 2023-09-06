using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayersApplication : PlayerApplication
{
    private TableTurnEffectState _state;

    private int _playersToTarget;

    public TargetPlayersApplication(Player player, Effect effect, TableTurnEffectState state, int playersToTarget) : base(player, effect)
    {
        _state = state;

        _playersToTarget = playersToTarget;
    }

    public override void DetermineTargets()
    {
        base.DetermineTargets();

        _state.EnterTargetSubState(this, _playersToTarget);
    }

    public void SetResponsiblePlayers(List<Player> responsiblePlayers)
    {
        foreach (Player player in responsiblePlayers)
        {
            ResponsiblePlayers.Add(player);
        }
    }

    public void SetTargets(List<Player> targets)
    {
        foreach (Player target in targets)
        {
            Targets.Add(target);
        }

        _effect.NextApplication();
    }
}
