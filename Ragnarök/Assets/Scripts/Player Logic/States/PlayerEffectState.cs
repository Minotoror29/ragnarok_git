using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectState : PlayerState
{
    private Effect _effect1;
    private Effect _effect2;

    private EffectsManager _effectsManager;

    private int _resolvedEffects = 0;

    private PlayerTargetState _targetState;

    public PlayerEffectState(Player player, Effect effect1, Effect effect2, EffectsManager effectsManager) : base(player)
    {
        _effect1 = effect1;
        _effect2 = effect2;

        _effectsManager = effectsManager;
    }

    public override void Enter()
    {
        _effect1.Activate(_effectsManager, _player, this);
    }

    public override void Exit()
    {
    }

    public void ResolveEffect()
    {
        ExitTargetState();

        _resolvedEffects++;

        if (_resolvedEffects == 2)
        {
            _player.TableTurnManager.NextPlayerTurn();
        } else
        {
            _effect2.Activate(_effectsManager, _player, this);
        }
    }

    public void EnterTargetState(PlayerTargetState targetState)
    {
        _targetState = targetState;

        _targetState.Enter();
    }

    public void ExitTargetState()
    {
        if (_targetState == null) return;

        _targetState.Exit();
        _targetState = null;
    }

    public override void SelectDeck(Card card)
    {
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
    }

    public override void UpdateLogic()
    {
        if (_targetState == null) return;

        _targetState.UpdateLogic();
    }
}
