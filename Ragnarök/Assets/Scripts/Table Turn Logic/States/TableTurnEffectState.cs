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

    private bool _opponentsVote = false;

    public TableTurnEffectState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, EffectData effect1, EffectData effect2, EffectsManager effectsManager, bool opponentsVote) : base(stateManager, tableTurnManager)
    {
        _player = player;

        _effect1 = effect1.Effect(player, this);
        _effect2 = effect2.Effect(player, this);

        _effectsManager = effectsManager;

        _opponentsVote = opponentsVote;
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
        _tableTurnManager.ActivePlayers.Remove(_player);
        _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager));
    }

    public void EnterTargetSubState(TargetPlayersApplication application, int playersToTarget)
    {
        if (!_opponentsVote)
        {
            _subState = new TableTurnTargetState(_tableTurnManager, _player, application, this, playersToTarget);
        } else
        {
            _subState = new TableTurnOpponentsTargetState(_tableTurnManager, _player, application, this);
        }
        _subState.Enter();
    }

    public void EnterValueSubState(CustomValueApplication application, bool add)
    {
        if (!_opponentsVote)
        {
            _subState = new TableTurnValueState(_tableTurnManager, _player, application, this, add);
        } else
        {
            _subState = new TableTurnOpponentsValueState(_tableTurnManager, _player, application, this, add);
        }
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
