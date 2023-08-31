using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] private TableTurnManager tableTurnManager;

    public List<Card> _cards;
    private List<Card> _graveyard;

    public void Initialize()
    {
        //_cards = new();
        _graveyard = new();

        //foreach (Card card in Resources.LoadAll<Card>("Data/Cards"))
        //{
        //    for (int i = 0; i < card.duplicates; i++)
        //    {
        //        _cards.Add(card);
        //    }
        //}
    }

    public Card DrawCard()
    {
        Card card = _cards[0];
        _cards.Remove(card);
        _graveyard.Add(card);

        if (_cards.Count == 0)
        {
            PutCardsBack();
        }

        return card;
    }

    private void Shuffle()
    {
        for (int i = _cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            Card temp = _cards[i];
            _cards[i] = _cards[j];
            _cards[j] = temp;
        }
    }

    public void PutCardsBack()
    {
        if (_graveyard.Count > 0)
        {
            foreach (Card card in _graveyard)
            {
                _cards.Add(card);
            }
        }

        Shuffle();

        _graveyard = new();
    }
}
