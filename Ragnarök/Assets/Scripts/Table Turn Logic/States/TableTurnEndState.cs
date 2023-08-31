using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnEndState : TableTurnState
{
    public TableTurnEndState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager, tableTurnManager)
    {
    }

    public override void Enter()
    {
        TableTurnManager.RoundState.TableTurnEnd();
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
