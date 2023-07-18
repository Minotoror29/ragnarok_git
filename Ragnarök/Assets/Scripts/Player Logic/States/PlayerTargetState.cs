using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetState : PlayerState
{
    private EffectsManager _effectsManager;
    private TargettingPlayersEffect _effect;
    private PlayerEffectState _effectState;
    private int _playersToTarget;
    private List<Player> _targetedPlayers;

    public PlayerTargetState(EffectsManager effectsManager, Player player, TargettingPlayersEffect effect, PlayerEffectState effectState, int playersToTarget, StateManager stateManager = null) : base(stateManager, player)
    {
        _effectsManager = effectsManager;
        _effect = effect;
        _effectState = effectState;
        _playersToTarget = playersToTarget;
    }

    public override void Enter()
    {
        _player.SelectionManager.Enable(this);
        _targetedPlayers = new List<Player>();
    }

    public override void Exit()
    {
        _player.SelectionManager.Disable();
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
        _player.SelectionManager.UpdateLogic();
    }
}
