using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnTargetState : TableTurnState
{
    private Player _player;
    private EffectsManager _effectsManager;
    private TargettingPlayersEffect _effect;
    private TableTurnEffectState _effectState;
    private int _playersToTarget;
    private List<Player> _targetedPlayers;

    public TableTurnTargetState(EffectsManager effectsManager, TableTurnManager tableTurnManager, Player player, TargettingPlayersEffect effect, TableTurnEffectState effectState, int playersToTarget, StateManager stateManager = null) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _effectsManager = effectsManager;
        _effect = effect;
        _effectState = effectState;
        _playersToTarget = playersToTarget;
    }

    public override void Enter()
    {
        _tableTurnManager.SelectionManager.Enable(this);
        _targetedPlayers = new List<Player>();
    }

    public override void Exit()
    {
        _tableTurnManager.SelectionManager.Disable();
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
            _effect.Resolve(_effectsManager, _player, _targetedPlayers, _effectState);
        }
    }

    public override void UpdateLogic()
    {
        _tableTurnManager.SelectionManager.UpdateLogic();
    }
}
