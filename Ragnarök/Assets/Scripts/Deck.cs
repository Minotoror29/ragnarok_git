using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, ISelectable
{
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private List<Card> cards;
    private List<Card> _graveyard;

    public void Initialize()
    {
        //cards = new();
        _graveyard = new();

        //foreach (Card card in Resources.LoadAll<Card>("Data/Cards"))
        //{
        //    for (int i = 0; i < card.duplicates; i++)
        //    {
        //        cards.Add(card);
        //    }
        //}
    }

    public void Select(TableTurnState state)
    {
        state.SelectDeck(this, cards[0]);
    }

    public void DrawCard()
    {
        Card card = cards[0];
        cards.Remove(card);
        _graveyard.Add(card);

        if (cards.Count == 0)
        {
            PutCardsBack();
        }
    }

    private void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public void PutCardsBack()
    {
        if (_graveyard.Count > 0)
        {
            foreach (Card card in _graveyard)
            {
                cards.Add(card);
            }
        }

        //Shuffle();

        _graveyard = new();
    }
}
