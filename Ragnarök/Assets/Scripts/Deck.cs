using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, ISelectable
{
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private List<Card> cards;
    public List<Card> _graveyard;

    public void Initialize()
    {
        _graveyard = new();
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
    }

    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);

            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
}
