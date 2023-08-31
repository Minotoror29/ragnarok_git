using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnConfirmTargetState : TableTurnState
{
    private ConfirmTargetDisplay _confirmTargetDisplay;

    private TableTurnState _targetState;

    private Player _player;
    private string _cardName;
    private Player _targetedPlayer;
    private UnityAction<Player> _confirmAction;
    private UnityAction _declineAction;

    public TableTurnConfirmTargetState(StateManager stateManager, TableTurnManager tableTurnManager, TableTurnState targetState, Player player, string cardName, Player targetedPlayer,
        UnityAction<Player> confirmAction) : base(stateManager, tableTurnManager)
    {
        _confirmTargetDisplay = TableTurnManager.ConfirmTargetDisplay;

        _targetState = targetState;
        _player = player;
        _cardName = cardName;
        _targetedPlayer = targetedPlayer;
        _confirmAction = confirmAction;
        _declineAction += Decline;
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

    private void Decline()
    {
        _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, TableTurnManager, _player.VCam, _targetState));
    }

    public override void UpdateLogic()
    {
    }
}
