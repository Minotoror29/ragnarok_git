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

    private int _activatedEffects = 0;

    private bool _opponentsVote = false;

    private List<Player> _playersWhoVotedPlay;

    private TitlePointsApplication _titlePointsApplication;
    public event Action<Player, Player> OnTarget;
    public event Action<Player, int> OnValue;

    public List<Player> PlayersWhoVotedPlay { get { return _playersWhoVotedPlay; } }

    public TableTurnEffectState(StateManager stateManager, TableTurnManager tableTurnManager, Player player,
        Card card, EffectData effect1, EffectData effect2, bool opponentsVote, List<Player> playersWhoVotedYes,
        TitlePointsApplication titlePointsApplication, Action<Player, Player> OnTargetEvent, Action<Player, int> OnValueEvent) : base(stateManager, tableTurnManager)
    {
        _player = player;

        _card = card;
        _effect1 = effect1.Effect(player, this);
        _effect2 = effect2.Effect(player, this);

        _opponentsVote = opponentsVote;

        _playersWhoVotedPlay = new();
        foreach (Player p in playersWhoVotedYes)
        {
            _playersWhoVotedPlay.Add(p);
        }

        _titlePointsApplication = titlePointsApplication;
        OnTarget = OnTargetEvent;
        OnValue = OnValueEvent;
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
        _effect1.Resolve();
        _effect2.Resolve();
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
            _player.OpponentsVoteForCard = false;
            _stateManager.ChangeState(new TableTurnOpponentsTargetState(_stateManager, TableTurnManager, _player, _card, application, OnTarget));
        }
    }

    public void EnterValueSubState(CustomValueApplication application, bool add)
    {
        if (!_opponentsVote)
        {
            _stateManager.ChangeState(new TableTurnValueState(_stateManager, TableTurnManager, _player, application, add, OnValue));
        } else
        {
            _player.OpponentsVoteForCard = false;
            _stateManager.ChangeState(new TableTurnOpponentsValueState(_stateManager, TableTurnManager, _player, application, add, OnValue));
        }
    }

    public override void UpdateLogic()
    {
    }
}
