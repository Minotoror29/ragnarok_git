using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnCardState : TableTurnState
{
    private Player _player;
    private Card _card;

    private List<Player> _votingPlayers;
    private int _playVotes;
    private int _discardVotes;

    private TitlePointsApplication _titlePointsApplication;
    public event Action<Player> OnVote;
    public event Action<Player, Player> OnTarget;

    public Player Player { get { return _player; } }

    public TableTurnCardState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _card = card;
    }

    public override void Enter()
    {
        _votingPlayers = new();
        if (_player.OpponentsVoteForCard)
        {
            foreach (Player opponent in _player.Opponents)
            {
                _votingPlayers.Add(opponent);
            }
        } else if (_card.vote)
        {
            _votingPlayers.Add(_player);
            foreach (Player opponent in _player.Opponents)
            {
                _votingPlayers.Add(opponent);
            }
        } else
        {
            _votingPlayers.Add(_player);
        }

        if (_card.titlePointsApplication != null)
        {
            _titlePointsApplication = _card.titlePointsApplication.Application(this);
        }

        TableTurnManager.CardDisplay.SetPlayer(_votingPlayers[0].PlayerName);

        TableTurnManager.CardDisplay.gameObject.SetActive(true);
        TableTurnManager.CardDisplay.SetCard(_card, this);
    }

    public override void Exit()
    {
        TableTurnManager.CardDisplay.ResetVotes();
        TableTurnManager.CardDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public void VotePlay()
    {
        _playVotes++;

        OnVote?.Invoke(_votingPlayers[0]);

        if (_player.OpponentsVoteForCard)
        {
            _votingPlayers[0].TitlePoints[TitlePointsId.Imperialism]++;
        }
        CheckIfVoteEnds();
    }

    public void VoteDiscard()
    {
        _discardVotes++;
        CheckIfVoteEnds();
    }

    public void CheckIfVoteEnds()
    {
        _votingPlayers.Remove(_votingPlayers[0]);

        if (_votingPlayers.Count == 0)
        {
            if (_playVotes > _discardVotes)
            {
                _stateManager.ChangeState(new TableTurnEffectState(_stateManager, TableTurnManager, _player,
                    _card, _card.effect1, _card.effect2, TableTurnManager.EffectsManager, _player.OpponentsVoteForCard,
                    _titlePointsApplication, OnTarget));
            } else if (_discardVotes > _playVotes)
            {
                _titlePointsApplication?.AssignPoints();
                _player.EndPlayerTurn();
                TableTurnManager.ActivePlayers.Remove(_player);
                _stateManager.ChangeState(new TableTurnCheckState(_stateManager, TableTurnManager));
            } else if (_playVotes == _discardVotes)
            {
                if (_card.titlePointsApplication != null)
                {
                    _titlePointsApplication = _card.titlePointsApplication.Application(this);
                }
                _votingPlayers.Add(_player);
                TableTurnManager.CardDisplay.SetPlayer(_votingPlayers[0].PlayerName);
            }
        }
        else
        {
            TableTurnManager.CardDisplay.SetPlayer(_votingPlayers[0].PlayerName);
        }
    }
}
