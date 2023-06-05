using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private TableTurnManager _tableTurnManager;
    [SerializeField] private EffectsManager effectsManager;

    private Card _card;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardEffect;

    [SerializeField] private Transform playVotesParent;
    [SerializeField] private Image playVote;
    private int _playVotes = 0;
    [SerializeField] private Transform discardVotesParent;
    [SerializeField] private Image discardVote;
    private int _discardVotes;
    private int _totalVotes = 0;
    private int _totalPlayers;

    public void Initialize(TableTurnManager tableTurnManager, List<Player> players)
    {
        _tableTurnManager = tableTurnManager;

        _totalPlayers = players.Count;
    }

    public void SetCard(Card card)
    {
        _card = card;

        cardName.text = card.name.ToUpper();
        cardEffect.text = card.effect1.description + " / " + card.effect2.description;

        _totalVotes = 0;
    }

    public void PlayCard()
    {
        if (_card.vote)
        {
            Vote(true);
        } else
        {
            _tableTurnManager.PlayCard(effectsManager, _card);
        }
    }

    public void DiscardCard()
    {
        if (_card.vote)
        {
            Vote(false);
        } else
        {
            _tableTurnManager.NextPlayerTurn();
        }
    }

    private void Vote(bool play)
    {
        if (play)
        {
            Instantiate(playVote, playVotesParent);
            _playVotes++;
        } else
        {
            Instantiate(discardVote, discardVotesParent);
            _discardVotes++;
        }

        _totalVotes++;

        if (_totalVotes == _totalPlayers)
        {
            if (_playVotes > _discardVotes)
            {
                _tableTurnManager.PlayCard(effectsManager, _card);
            } else if (_discardVotes > _playVotes)
            {
                _tableTurnManager.NextPlayerTurn();
            } else if (_playVotes == _discardVotes)
            {
                _tableTurnManager.PlayCard(effectsManager, _card);
            }
        }
    }
}
