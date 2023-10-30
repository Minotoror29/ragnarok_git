using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private TableTurnCardState _state;

    [SerializeField] private Card card;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardEffect;
    [SerializeField] private TextMeshProUGUI playerText;

    [SerializeField] private Transform playVotesParent;
    [SerializeField] private Image playVote;
    [SerializeField] private Transform discardVotesParent;
    [SerializeField] private Image discardVote;
    private List<Image> _totalVotes;

    public void Initialize()
    {
        card.Initialize(this);
    }

    public void SetCard(CardData cardData, TableTurnCardState state)
    {
        _state = state;

        cardName.text = cardData.name.ToUpper();
        cardEffect.text = cardData.effect1.description + " / " + cardData.effect2.description;

        _totalVotes = new List<Image>();
    }

    public void SetPlayer(string playerName)
    {
        playerText.text = playerName + " is deciding to play :";
    }

    public void PlayCard()
    {
        Image newVote = Instantiate(playVote, playVotesParent);
        _totalVotes.Add(newVote);

        _state.VotePlay();
    }

    public void DiscardCard()
    {
        Image newVote = Instantiate(discardVote, discardVotesParent);
        _totalVotes.Add(newVote);

        _state.VoteDiscard();
    }

    public void ResetVotes()
    {
        foreach (Image vote in _totalVotes)
        {
            Destroy(vote.gameObject);
        }
    }
}
