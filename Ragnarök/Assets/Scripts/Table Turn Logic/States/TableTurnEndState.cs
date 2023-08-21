using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnEndState : TableTurnState
{
    private CinemachineVirtualCamera _currentCam;

    public TableTurnEndState(StateManager stateManager, TableTurnManager tableTurnManager, CinemachineVirtualCamera currentCam) : base(stateManager, tableTurnManager)
    {
        _currentCam = currentCam;
    }

    public override void Enter()
    {
        _currentCam.gameObject.SetActive(false);
        _tableTurnManager.RoundState.TableTurnEnd();
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }
}
