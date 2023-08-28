using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    private TableTurnCardState _state;

    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardEffect;
    [SerializeField] private TextMeshProUGUI playerText;

    [SerializeField] private Transform playVotesParent;
    [SerializeField] private Image playVote;
    [SerializeField] private Transform discardVotesParent;
    [SerializeField] private Image discardVote;
    private List<Image> _totalVotes;

    public void SetCard(Card card, TableTurnCardState state)
    {
        _state = state;

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
