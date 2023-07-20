using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnEffectState : TableTurnState
{
    private Player _player;

    private Effect _effect1;
    private Effect _effect2;

    private EffectsManager _effectsManager;

    private int _resolvedEffects = 0;

    private TableTurnState _subState;

    public TableTurnEffectState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, EffectData effect1, EffectData effect2, EffectsManager effectsManager) : base(stateManager, tableTurnManager)
    {
        _player = player;

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

        _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager, _player));
    }

    public void EnterTargetSubState(TargettingPlayersEffect effect, int playersToTarget)
    {
        _subState = new TableTurnTargetState(_effectsManager, _tableTurnManager, _player, effect, this, playersToTarget);
        _subState.Enter();
    }

    public void EnterValueSubState(CustomValueApplication application, bool add)
    {
        _subState = new TableTurnValueState(_tableTurnManager, _player, application, add);
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
