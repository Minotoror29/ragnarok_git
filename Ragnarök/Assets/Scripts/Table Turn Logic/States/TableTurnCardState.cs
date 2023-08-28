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

    public TableTurnCardState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _card = card;
    }

    public override void Enter()
    {
        _votingPlayers = new();
        if (_card.vote)
        {
            _votingPlayers.Add(_player);
            foreach (Player opponent in _player.Opponents)
            {
                _votingPlayers.Add(opponent);
            }
        } else if (_player.OpponentsVoteForCard)
        {
            foreach (Player opponent in _player.Opponents)
            {
                _votingPlayers.Add(opponent);
            }
        } else
        {
            _votingPlayers.Add(_player);
        }

        _tableTurnManager.CardDisplay.SetPlayer(_votingPlayers[0].PlayerName);

        _tableTurnManager.CardDisplay.gameObject.SetActive(true);
        _tableTurnManager.CardDisplay.SetCard(_card, this);
    }

    public override void Exit()
    {
        _tableTurnManager.CardDisplay.ResetVotes();
        _tableTurnManager.CardDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
    }

    public void VotePlay()
    {
        _playVotes++;
        if (_card.titlePointsApplication != null)
        {
            _votingPlayers[0].TitlePoints[_card.titlePointsApplication.titlePointsId] += _card.titlePointsApplication.value;
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
                _stateManager.ChangeState(new TableTurnEffectState(_stateManager, _tableTurnManager, _player, _card, _card.effect1, _card.effect2, _tableTurnManager.EffectsManager, _player.OpponentsVoteForCard));
            } else if (_discardVotes > _playVotes)
            {
                _player.EndPlayerTurn();
                _tableTurnManager.ActivePlayers.Remove(_player);
                _stateManager.ChangeState(new TableTurnCheckState(_stateManager, _tableTurnManager));
            }
        }
        else
        {
            _tableTurnManager.CardDisplay.SetPlayer(_votingPlayers[0].PlayerName);
        }
    }
}
