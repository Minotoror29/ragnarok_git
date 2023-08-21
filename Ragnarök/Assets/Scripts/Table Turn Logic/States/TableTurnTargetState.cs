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

    private UnityAction<Player> _selectAction;
    private UnityAction<Player> _confirmAction;

    public TableTurnTargetState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card, TargetPlayersApplication playerApplication, int playersToTarget) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _card = card;
        _playerApplication = playerApplication;
        _playersToTarget = playersToTarget;

        _selectAction += SelectPlayer;
        _confirmAction += Confirm;
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

        _stateManager.ChangeState(new TableTurnTransitionState(
            _stateManager, _tableTurnManager, selectedPlayer.TargetCam,
            new TableTurnConfirmTargetState(_stateManager, _tableTurnManager, this, _player, _card.cardName, selectedPlayer, _confirmAction)));
    }

    private void Confirm(Player selectedPlayer)
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
        }
    }

    public override void UpdateLogic()
    {
        _tableTurnManager.SelectionManager.UpdateLogic();
    }
}
