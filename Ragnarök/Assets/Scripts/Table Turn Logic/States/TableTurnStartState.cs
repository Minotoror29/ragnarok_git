using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnStartState : TableTurnState
{
    public TableTurnStartState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager, tableTurnManager)
    {
    }

    public override void Enter()
    {
        _tableTurnManager.Clock.AddHours(1);

        _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, _tableTurnManager, _tableTurnManager.ActivePlayers[0]));
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
