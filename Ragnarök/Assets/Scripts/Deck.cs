using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, ISelectable
{
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private List<Card> cards;

    public void Select(TableTurnState state)
    {
        state.SelectDeck(cards[0]);
    }
}
