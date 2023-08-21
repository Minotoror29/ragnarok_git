using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnConfirmTargetState : TableTurnState
{
    private ConfirmTargetDisplay _confirmTargetDisplay;

    private string _cardName;
    private Player _targetedPlayer;
    private UnityAction<Player> _confirmAction;
    private UnityAction _declineAction;

    public TableTurnConfirmTargetState(StateManager stateManager, TableTurnManager tableTurnManager) : base(stateManager, tableTurnManager)
    {
        _confirmTargetDisplay = _tableTurnManager.ConfirmTargetDisplay;
    }

    public override void Enter()
    {
        _confirmTargetDisplay.gameObject.SetActive(true);
        _confirmTargetDisplay.SetText(_cardName, _targetedPlayer.PlayerName);
        _confirmTargetDisplay.SetTargetedPlayer(_targetedPlayer);
        _confirmTargetDisplay.SetButtons(_confirmAction, _declineAction);
    }

    public override void Exit()
    {
        _confirmTargetDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }
}
