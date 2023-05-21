using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnTransitionState : TableTurnState
{
    private float _transitionTime;
    private float _transitionTimer;

    public TableTurnTransitionState(TableTurnManager tableTurnManager, Player player) : base(tableTurnManager, player)
    {
    }

    public override void Enter()
    {
        _transitionTime = Camera.main.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time;
        _player.VCam.gameObject.SetActive(true);
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
                _tableTurnManager.StartPlayerTurn();
            }
        }
    }
}
