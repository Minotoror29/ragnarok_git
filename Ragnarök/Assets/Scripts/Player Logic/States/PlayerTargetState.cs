using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetState : PlayerState
{
    private EffectsManager _effectsManager;
    private TargettingPlayersEffect _effect;
    private TargetPlayersApplication _application;
    private PlayerEffectState _effectState;
    private int _playersToTarget;
    private List<Player> _targetedPlayers;

    public PlayerTargetState(EffectsManager effectsManager, Player player, TargettingPlayersEffect effect, TargetPlayersApplication application, PlayerEffectState effectState, int playersToTarget) : base(player)
    {
        _effectsManager = effectsManager;
        _effect = effect;
        _application = application;
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
