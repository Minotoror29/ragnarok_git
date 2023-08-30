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

    public TableTurnEffectState(StateManager stateManager, TableTurnManager tableTurnManager, Player player,
        Card card, EffectData effect1, EffectData effect2, EffectsManager effectsManager, bool opponentsVote, TitlePointsApplication titlePointsApplication) : base(stateManager, tableTurnManager)
    {
        _player = player;

        _card = card;
        _effect1 = effect1.Effect(player, this);
        _effect2 = effect2.Effect(player, this);

        _effectsManager = effectsManager;

        _opponentsVote = opponentsVote;

        _titlePointsApplication = titlePointsApplication;
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
        _tableTurnManager.ActivePlayers.Remove(_player);
        if (_tableTurnManager.Clock.HasHourChanged)
        {
            _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, _tableTurnManager, _tableTurnManager.TopCam,
                new TableTurnClockState(_stateManager, _tableTurnManager)));
        }
        else
        {
            _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager));
        }
    }

    public void EnterTargetSubState(TargetPlayersApplication application, int playersToTarget)
    {
        if (!_opponentsVote)
        {
            _stateManager.ChangeState(new TableTurnTargetState(_stateManager, _tableTurnManager, _player, _card, application, playersToTarget));
        } else
        {
            _stateManager.ChangeState(new TableTurnOpponentsTargetState(_stateManager, _tableTurnManager, _player, _card, application));
        }
    }

    public void EnterValueSubState(CustomValueApplication application, bool add)
    {
        if (!_opponentsVote)
        {
            _stateManager.ChangeState(new TableTurnValueState(_stateManager, _tableTurnManager, _player, application, add));
        } else
        {
            _stateManager.ChangeState(new TableTurnOpponentsValueState(_stateManager, _tableTurnManager, _player, application, add));
        }
    }

    public override void UpdateLogic()
    {
    }
}
