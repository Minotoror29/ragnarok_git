using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnTargetState : TableTurnState
{
    private Player _player;
    private Card _card;
    private TargetPlayersApplication _playerApplication;
    private int _playersToTarget;
    private List<Player> _targetedPlayers;

    private event Action<Player> _selectAction;
    private UnityAction<Player> _confirmAction;

    public event Action<Player, Player> OnTarget;

    public TableTurnTargetState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card,
        TargetPlayersApplication playerApplication, int playersToTarget, Action<Player, Player> OnTargetEvent) : base(stateManager, tableTurnManager)
    {
        _player = player;

        _card = card;
        _playerApplication = playerApplication;
        _playersToTarget = playersToTarget;

        _selectAction += SelectPlayer;
        _confirmAction += Confirm;

        OnTarget = OnTargetEvent;
    }

    public override void Enter()
    {
        _targetedPlayers = new List<Player>();

        foreach (Player player in _player.Opponents)
        {
            player.PlayerOverlay.EnableSelection(_selectAction);
        }

        TableTurnManager.TargetDisplay.gameObject.SetActive(true);
        TableTurnManager.TargetDisplay.SetTargetText(_player.PlayerName);
    }

    public override void Exit()
    {
        foreach (Player player in _player.Opponents)
        {
            player.PlayerOverlay.DisableSelection();
        }

        TableTurnManager.TargetDisplay.gameObject.SetActive(false);
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
        _stateManager.ChangeState(new TableTurnTransitionState(
            _stateManager, TableTurnManager, selectedPlayer.TargetCam,
            new TableTurnConfirmTargetState(_stateManager, TableTurnManager, this, _player, _card.cardName, selectedPlayer, _confirmAction)));
    }

    private void Confirm(Player targetedPlayer)
    {
        OnTarget?.Invoke(_player, targetedPlayer);

        TableTurnManager.ConfirmTargetDisplay.gameObject.SetActive(false);

        if (_targetedPlayers.Contains(targetedPlayer))
        {
            _targetedPlayers.Remove(targetedPlayer);
        }
        else
        {
            _targetedPlayers.Add(targetedPlayer);
        }

        if (_targetedPlayers.Count == _playersToTarget)
        {
            _playerApplication.SetTargets(_targetedPlayers);
        }
    }

    public override void UpdateLogic()
    {
    }
}
