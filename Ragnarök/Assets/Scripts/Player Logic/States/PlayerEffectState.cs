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

    public PlayerEffectState(Player player, EffectData effect1, EffectData effect2, EffectsManager effectsManager) : base(player)
    {
        _effect1 = effect1.Effect(player, this);
        _effect2 = effect2.Effect(player, this);

        _effectsManager = effectsManager;
    }

    public override void Enter()
    {
        _effect1.Activate();
    }

    public override void Exit()
    {
    }

    public void NextEffect()
    {
        ExitSubState();

        _resolvedEffects++;

        if (_resolvedEffects == 2)
        {
            ResolveEffects();
        } else
        {
            _effect2.Activate();
        }
    }

    private void ResolveEffects()
    {
        _effect1.Resolve(_effectsManager);
        _effect2.Resolve(_effectsManager);

        _player.EndPlayerTurn();
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
