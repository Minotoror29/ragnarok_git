using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private RoundManager _roundManager;
    [SerializeField] private EffectsManager effectsManager;
    private Player _player;
    private TableTurnCardState _state;

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
    private List<Player> _totalPlayers;
    private int _votingPlayers;

    public void Initialize(RoundManager roundManager)
    {
        _roundManager = roundManager;
    }

    public void SetCard(Player player, Card card, bool opponentsVote, TableTurnCardState state)
    {
        _player = player;
        _state = state;
        _card = card;
        _totalPlayers = _roundManager.ActivePlayers;

        cardName.text = card.name.ToUpper();
        cardEffect.text = card.effect1.description + " / " + card.effect2.description;

        totalVotes = new List<Image>();
        _playVotes = 0;
        _discardVotes = 0;

        if (_card.vote || opponentsVote)
        {
            _voting = true;

            if (opponentsVote)
            {
                _votingPlayers = _totalPlayers.Count - 1;
            } else
            {
                _votingPlayers = _totalPlayers.Count;
            }
        }
    }

    public void PlayCard()
    {
        if (_voting)
        {
            Vote(true);
        } else
        {
            _state.PlayCard(effectsManager, _card);
        }
    }

    public void DiscardCard()
    {
        if (_voting)
        {
            Vote(false);
        } else
        {
            _state.DiscardCard();
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

        if (totalVotes.Count == _votingPlayers)
        {
            if (_playVotes > _discardVotes)
            {
                _state.PlayCard(effectsManager, _card);
                _voting = false;
                ResetVotes();
            } else if (_discardVotes > _playVotes)
            {
                _state.DiscardCard();
                _voting = false;
                ResetVotes();
            } else if (_playVotes == _discardVotes)
            {
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
