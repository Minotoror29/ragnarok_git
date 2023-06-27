using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectState : PlayerState
{
    private Effect _effect1;
    private Effect _effect2;

    private EffectsManager _effectsManager;

    private int _resolvedEffects = 0;

    private PlayerState _subState;

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
        ExitSubState();

        _resolvedEffects++;

        if (_resolvedEffects == 2)
        {
            _player.TableTurnManager.NextPlayerTurn();
        } else
        {
            _effect2.Activate(_effectsManager, _player, this);
        }
    }

    public void EnterSubState(PlayerState subState)
    {
        _subState = subState;

        _subState.Enter();
    }

    public void ExitSubState()
    {
        if (_subState == null) return;

        _subState.Exit();
        _subState = null;
    }

    public override void UpdateLogic()
    {
        if (_subState == null) return;

        _subState.UpdateLogic();
    }
}
