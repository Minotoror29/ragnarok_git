using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnCardState : TableTurnState
{
    private Player _player;
    private Card _card;
    private Effect _effect1;
    private Effect _effect2;
    private bool _canTriggerRagnarok;
    private bool _canAvoidRagnarok;

    private List<Player> _votingPlayers;
    private int _playVotes;
    private int _discardVotes;
    private List<Player> _playersWhoVotedPlay;
    private List<Player> _playersWhoVotedDiscard;

    private TitlePointsApplication _titlePointsApplication;
    public event Action<Player> OnVote;
    public event Action<Player, Player> OnTarget;
    public event Action<Player, int> OnValue;

    public Player Player { get { return _player; } }
    public bool CanTriggerRagnarok { set { _canTriggerRagnarok = value; } }
    public bool CanAvoidRagnarok { set { _canAvoidRagnarok = value; } }

    public TableTurnCardState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _card = card;
        _effect1 = card.effect1.Effect(card, player);
        _effect2 = card.effect2.Effect(card, player);
        _canTriggerRagnarok = _card.canTriggerRagnarok;
        _canAvoidRagnarok = _card.canAvoidRagnarok;
        _effect1.CheckGameState(this);
        _effect2.CheckGameState(this);

        _playersWhoVotedPlay = new();
        _playersWhoVotedDiscard = new();
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
        if (!_playersWhoVotedPlay.Contains(_votingPlayers[0]))
        {
            _playersWhoVotedPlay.Add(_votingPlayers[0]);
        }

        OnVote?.Invoke(_votingPlayers[0]);

        if (_player.OpponentsVoteForCard)
        {
            if (_votingPlayers[0] != _player)
            {
                _votingPlayers[0].TitlePoints[TitlePointsId.Imperialism]++;
            }
        }
        CheckIfVoteEnds();
    }

    public void VoteDiscard()
    {
        _discardVotes++;
        if (!_playersWhoVotedDiscard.Contains(_votingPlayers[0]))
        {
            _playersWhoVotedDiscard.Add(_votingPlayers[0]);
        }
        CheckIfVoteEnds();
    }

    public void CheckIfVoteEnds()
    {
        _votingPlayers.Remove(_votingPlayers[0]);

        if (_votingPlayers.Count == 0)
        {
            if (_playVotes > _discardVotes)
            {
                if (_canTriggerRagnarok)
                {
                    TableTurnManager.RagnarokResponsiblePlayers.Clear();
                    foreach (Player player in _playersWhoVotedPlay)
                    {
                        TableTurnManager.RagnarokResponsiblePlayers.Add(player);
                    }
                }

                _stateManager.ChangeState(new TableTurnEffectState(_stateManager, TableTurnManager, _player,
                    _card, _effect1, _effect2, _player.OpponentsVoteForCard, _playersWhoVotedPlay,
                    _titlePointsApplication, OnTarget, OnValue));
            } else if (_discardVotes > _playVotes)
            {
                if (_canAvoidRagnarok)
                {
                    TableTurnManager.RagnarokResponsiblePlayers.Clear();
                    foreach (Player player in _playersWhoVotedDiscard)
                    {
                        TableTurnManager.RagnarokResponsiblePlayers.Add(player);
                    }
                }

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
