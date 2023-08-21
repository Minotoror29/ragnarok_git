using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnTransitionState : TableTurnState
{
    private CinemachineVirtualCamera _currentCam;
    private CinemachineVirtualCamera _nextCam;

    private TableTurnState _nextState;

    private float _transitionTime;
    private float _transitionTimer;

    public TableTurnTransitionState(StateManager stateManager, TableTurnManager tableTurnManager, CinemachineVirtualCamera currentCam, CinemachineVirtualCamera nextCam, TableTurnState nextState) : base(stateManager, tableTurnManager)
    {
        _currentCam = currentCam;
        _nextCam = nextCam;
        _nextState = nextState;
    }

    public override void Enter()
    {
        _transitionTime = Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time;
        _currentCam?.gameObject.SetActive(false);
        _nextCam.gameObject.SetActive(true);
        _transitionTimer = _transitionTime;
    }

    public override void Exit()
    {
        
    }

    public override void UpdateLogic()
    {
        if (_transitionTimer > 0f)
        {
            _transitionTimer -= Time.deltaTime;

            if (_transitionTimer <= 0f)
            {
                _stateManager.ChangeState(_nextState);
            }
        }
    }
}
