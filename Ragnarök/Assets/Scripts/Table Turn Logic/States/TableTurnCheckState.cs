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
        if (!_tableTurnManager.RoundState.IsRoundOver())
        {
            if (_tableTurnManager.ActivePlayers.Count == 0)
            {
                _stateManager.ChangeState(new TableTurnEndState(_stateManager, _tableTurnManager));
            }
            else
            {
                _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, _tableTurnManager, _tableTurnManager.ActivePlayers[0].VCam,
                    new TableTurnPlayingState(_stateManager, _tableTurnManager, _tableTurnManager.ActivePlayers[0])));
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
