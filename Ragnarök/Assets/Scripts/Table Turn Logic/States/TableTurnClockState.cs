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
        _tableTurnManager.Clock.SetHoursText();
        _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
