using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : RoundState
{
    public RoundStartState(StateManager stateManager, RoundManager roundManager, int roundNumber) : base(stateManager, roundManager, roundNumber)
    {
    }

    public override void Enter()
    {
        _roundManager.Clock.SetHour(0);

        foreach (Player player in _roundManager.Players)
        {
            player.SetOpponents(_roundManager.Players);
            player.SetPoints(_roundManager.PlayersStartPoints);
            player.ResetContinuousEffects();
        }

        _roundManager.TableTurnManager.SetActivePlayers(_roundManager.Players);

        _stateManager.ChangeState(new RoundTableTurnState(_stateManager, _roundManager, _roundNumber, 0));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
