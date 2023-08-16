using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnTargetState : TableTurnState
{
    private Player _player;
    private TargetPlayersApplication _playerApplication;
    private TableTurnEffectState _effectState;
    private int _playersToTarget;
    private List<Player> _targetedPlayers;

    private UnityAction<Player> _selectAction;

    public TableTurnTargetState(TableTurnManager tableTurnManager, Player player, TargetPlayersApplication playerApplication, TableTurnEffectState effectState, int playersToTarget, StateManager stateManager = null) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _playerApplication = playerApplication;
        _effectState = effectState;
        _playersToTarget = playersToTarget;
    }

    public override void Enter()
    {
        _tableTurnManager.SelectionManager.Enable(this);
        _targetedPlayers = new List<Player>();

        _selectAction += SelectPlayer;

        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().EnableSelection(_selectAction);
        }
    }

    public override void Exit()
    {
        _tableTurnManager.SelectionManager.Disable();

        for (int i = 0; i < _tableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            _tableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().DisableSelection();
        }
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
        if (selectedPlayer == _player) return;

        if (_targetedPlayers.Contains(selectedPlayer))
        {
            _targetedPlayers.Remove(selectedPlayer);
        } else
        {
            _targetedPlayers.Add(selectedPlayer);
        }

        if (_targetedPlayers.Count == _playersToTarget)
        {
            _playerApplication.SetTargets(_targetedPlayers);
            _effectState.ExitSubState();
        }
    }

    public override void UpdateLogic()
    {
        _tableTurnManager.SelectionManager.UpdateLogic();
    }
}
