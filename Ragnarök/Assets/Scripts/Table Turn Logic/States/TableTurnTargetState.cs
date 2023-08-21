using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnTargetState : TableTurnState
{
    private Player _player;
    private Card _card;
    private TargetPlayersApplication _playerApplication;
    private TableTurnEffectState _effectState;
    private int _playersToTarget;
    private List<Player> _targetedPlayers;

    private UnityAction<Player> _selectAction;
    private UnityAction<Player> _confirmAction;
    private UnityAction _declineAction;

    public TableTurnTargetState(TableTurnManager tableTurnManager, Player player, Card card, TargetPlayersApplication playerApplication, TableTurnEffectState effectState, int playersToTarget, StateManager stateManager = null) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _card = card;
        _playerApplication = playerApplication;
        _effectState = effectState;
        _playersToTarget = playersToTarget;

        _selectAction += SelectPlayer;
        _confirmAction += Confirm;
        _declineAction += Decline;
    }

    public override void Enter()
    {
        _targetedPlayers = new List<Player>();

        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().EnableSelection(_selectAction);
        }
    }

    public override void Exit()
    {
        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().DisableSelection();
        }
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
        if (selectedPlayer == _player) return;

        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().DisableSelection();
        }

        _tableTurnManager.ConfirmTargetDisplay.gameObject.SetActive(true);
        _tableTurnManager.ConfirmTargetDisplay.SetText(_card.name, selectedPlayer.PlayerName);
        _tableTurnManager.ConfirmTargetDisplay.SetTargetedPlayer(selectedPlayer);
        _tableTurnManager.ConfirmTargetDisplay.SetButtons(_confirmAction, _declineAction);
    }

    public void Confirm(Player selectedPlayer)
    {
        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().EnableSelection(_selectAction);
        }

        _tableTurnManager.ConfirmTargetDisplay.gameObject.SetActive(false);

        if (_targetedPlayers.Contains(selectedPlayer))
        {
            _targetedPlayers.Remove(selectedPlayer);
        }
        else
        {
            _targetedPlayers.Add(selectedPlayer);
        }

        if (_targetedPlayers.Count == _playersToTarget)
        {
            _playerApplication.SetTargets(_targetedPlayers);
            _effectState.ExitSubState();
        }
    }

    public void Decline()
    {
        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().EnableSelection(_selectAction);
        }

        _tableTurnManager.ConfirmTargetDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
        _tableTurnManager.SelectionManager.UpdateLogic();
    }
}
