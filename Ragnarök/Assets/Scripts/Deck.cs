using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, ISelectable
{
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private List<Card> cards;

    public void Select()
    {
        DrawCard();
    }

    private void DrawCard()
    {
        tableTurnManager.DrawCard(cards[0]);
    }
}
