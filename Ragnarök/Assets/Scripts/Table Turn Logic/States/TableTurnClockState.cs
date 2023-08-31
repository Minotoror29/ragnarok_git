using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnClockState : TableTurnState
{
    public TableTurnClockState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager, tableTurnManager)
    {
    }

    public override void Enter()
    {
        TableTurnManager.Clock.SetHoursText();
        _stateManager.ChangeState(new TableTurnCheckState(_stateManager, TableTurnManager));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
