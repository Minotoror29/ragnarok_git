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
        Debug.Log("Select " + _playersToTarget.ToString() + " players");

        _player.SelectionManager.Enable(this);
        _targetedPlayers = new List<Player>();
    }

    public override void Exit()
    {
        _player.SelectionManager.Disable();
    }

    public override void SelectDeck(Card card)
    {
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
            _application.Resolve(_effectsManager, _player, _effect, _targetedPlayers, _effectState);
        }
    }

    public override void UpdateLogic()
    {
        _player.SelectionManager.UpdateLogic();
    }
}
