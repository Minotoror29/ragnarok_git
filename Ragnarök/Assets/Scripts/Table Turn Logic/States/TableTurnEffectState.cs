using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnEffectState : TableTurnState
{
    private Player _player;

    private Card _card;
    private Effect _effect1;
    private Effect _effect2;

    private EffectsManager _effectsManager;

    private int _activatedEffects = 0;

    private bool _opponentsVote = false;

    private TitlePointsApplication _titlePointsApplication;
    public Action<Player, Player> OnTarget;

    public TableTurnEffectState(StateManager stateManager, TableTurnManager tableTurnManager, Player player,
        Card card, EffectData effect1, EffectData effect2, EffectsManager effectsManager, bool opponentsVote,
        TitlePointsApplication titlePointsApplication, Action<Player, Player> OnTargetEvent) : base(stateManager, tableTurnManager)
    {
        _player = player;

        _card = card;
        _effect1 = effect1.Effect(player, this);
        _effect2 = effect2.Effect(player, this);

        _effectsManager = effectsManager;

        _opponentsVote = opponentsVote;

        _titlePointsApplication = titlePointsApplication;
        OnTarget = OnTargetEvent;
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
        _activatedEffects++;

        if (_activatedEffects == 2)
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
        _titlePointsApplication?.AssignPoints();

        _player.EndPlayerTurn();
        TableTurnManager.ActivePlayers.Remove(_player);
        if (TableTurnManager.Clock.HasHourChanged)
        {
            _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, TableTurnManager, TableTurnManager.TopCam,
                new TableTurnClockState(_stateManager, TableTurnManager)));
        }
        else
        {
            _stateManager.ChangeState(new TableTurnCheckState(_stateManager, TableTurnManager));
        }
    }

    public void EnterTargetSubState(TargetPlayersApplication application, int playersToTarget)
    {
        if (!_opponentsVote)
        {
            _stateManager.ChangeState(new TableTurnTargetState(_stateManager, TableTurnManager, _player, _card, application, playersToTarget, OnTarget));
        } else
        {
            _stateManager.ChangeState(new TableTurnOpponentsTargetState(_stateManager, TableTurnManager, _player, _card, application));
        }
    }

    public void EnterValueSubState(CustomValueApplication application, bool add)
    {
        if (!_opponentsVote)
        {
            _stateManager.ChangeState(new TableTurnValueState(_stateManager, TableTurnManager, _player, application, add));
        } else
        {
            _stateManager.ChangeState(new TableTurnOpponentsValueState(_stateManager, TableTurnManager, _player, application, add));
        }
    }

    public override void UpdateLogic()
    {
    }
}
