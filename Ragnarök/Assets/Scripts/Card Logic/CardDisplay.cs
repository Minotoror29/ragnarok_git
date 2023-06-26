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

    private bool _voting = false;
    [SerializeField] private Transform playVotesParent;
    [SerializeField] private Image playVote;
    private int _playVotes = 0;
    [SerializeField] private Transform discardVotesParent;
    [SerializeField] private Image discardVote;
    private int _discardVotes = 0;
    private List<Image> totalVotes;
    private int _totalPlayers;

    public void Initialize(TableTurnManager tableTurnManager, List<Player> players)
    {
        _tableTurnManager = tableTurnManager;

        _totalPlayers = players.Count;
    }

    public void SetCard(Card card, bool voting)
    {
        _card = card;

        cardName.text = card.name.ToUpper();
        cardEffect.text = card.effect1.description + " / " + card.effect2.description;

        totalVotes = new List<Image>();

        if (_card.vote || voting)
        {
            _voting = true;
        }
    }

    public void PlayCard()
    {
        if (_voting)
        {
            Vote(true);
        } else
        {
            _tableTurnManager.PlayCard(effectsManager, _card);
        }
    }

    public void DiscardCard()
    {
        if (_voting)
        {
            Vote(false);
        } else
        {
            _tableTurnManager.NextPlayerTurn();
        }
    }

    private void Vote(bool play)
    {
        Image newVote;

        if (play)
        {
            newVote = Instantiate(playVote, playVotesParent);
            _playVotes++;
        } else
        {
            newVote = Instantiate(discardVote, discardVotesParent);
            _discardVotes++;
        }

        totalVotes.Add(newVote);

        if (totalVotes.Count == _totalPlayers)
        {
            if (_playVotes > _discardVotes)
            {
                _tableTurnManager.PlayCard(effectsManager, _card);
                _voting = false;
                ResetVotes();
            } else if (_discardVotes > _playVotes)
            {
                _tableTurnManager.NextPlayerTurn();
                _voting = false;
                ResetVotes();
            } else if (_playVotes == _discardVotes)
            {
                _tableTurnManager.PlayCard(effectsManager, _card);
                _voting = false;
                ResetVotes();
            }
        }
    }

    private void ResetVotes()
    {
        foreach (Image vote in totalVotes)
        {
            Destroy(vote.gameObject);
        }
    }
}
