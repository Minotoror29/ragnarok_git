using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnCheckState : TableTurnState
{

    public TableTurnCheckState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager, tableTurnManager)
    {
    }

    public override void Enter()
    {
        if (!TableTurnManager.RoundState.IsRoundOver())
        {
            if (TableTurnManager.ActivePlayers.Count == 0)
            {
                _stateManager.ChangeState(new TableTurnEndState(_stateManager, TableTurnManager));
            }
            else
            {
                _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, TableTurnManager, TableTurnManager.ActivePlayers[0].VCam,
                    new TableTurnPlayingState(_stateManager, TableTurnManager, TableTurnManager.ActivePlayers[0])));
            }
        }
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
