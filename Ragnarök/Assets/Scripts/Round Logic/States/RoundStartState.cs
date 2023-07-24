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
        _roundManager.Deck.PutCardsBack();

        foreach (Player player in _roundManager.ActivePlayers)
        {
            player.SetToInactive();
            player.SetOpponents(_roundManager.ActivePlayers);
            player.SetPoints(_roundManager.PlayersStartPoints);
            player.ResetContinuousEffects();
        }

        _stateManager.ChangeState(new RoundTableTurnState(_stateManager, _roundManager, _roundNumber, 0));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
