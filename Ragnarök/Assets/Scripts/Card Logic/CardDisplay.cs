using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private EffectsManager effectsManager;
    private Player _player;
    private TableTurnCardState _state;

    private Card _card;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardEffect;
    [SerializeField] private TextMeshProUGUI playerText;

    [SerializeField] private Transform playVotesParent;
    [SerializeField] private Image playVote;
    [SerializeField] private Transform discardVotesParent;
    [SerializeField] private Image discardVote;
    private List<Image> _totalVotes;

    public void SetCard(Player player, Card card, bool opponentsVote, TableTurnCardState state)
    {
        _player = player;
        _state = state;
        _card = card;

        cardName.text = card.name.ToUpper();
        cardEffect.text = card.effect1.description + " / " + card.effect2.description;

        _totalVotes = new List<Image>();
    }

    public void SetPlayer(string playerName)
    {
        playerText.text = playerName + " is deciding to play :";
    }

    public void PlayCard()
    {
        if (_card.titlePointsApplication != null)
        {
            _player.TitlePoints[_card.titlePointsApplication.titlePointsId] += _card.titlePointsApplication.value;
        }
        _state.VotePlay();

        Image newVote = Instantiate(playVote, playVotesParent);
        _totalVotes.Add(newVote);
    }

    public void DiscardCard()
    {
        _state.VoteDiscard();

        Image newVote = Instantiate(discardVote, discardVotesParent);
        _totalVotes.Add(newVote);
    }

    public void ResetVotes()
    {
        foreach (Image vote in _totalVotes)
        {
            Destroy(vote.gameObject);
        }
    }
}
