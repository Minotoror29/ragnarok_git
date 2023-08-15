using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnClockState : TableTurnState
{
    private float _transitionTime;
    private float _transitionTimer;

    public TableTurnClockState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager, tableTurnManager)
    {
    }

    public override void Enter()
    {
        _transitionTime = Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time;
        _tableTurnManager.TopCam.gameObject.SetActive(true);
        _transitionTimer = _transitionTime;
    }

    public override void Exit()
    {
        _tableTurnManager.TopCam.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
        if (_transitionTimer > 0)
        {
            _transitionTimer -= Time.deltaTime;
        } else
        {
            _tableTurnManager.Clock.SetHoursText();
            _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager));
        }
    }
}
