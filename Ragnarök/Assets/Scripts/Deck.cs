using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, ISelectable
{
    [SerializeField] private TableTurnManager tableTurnManager;

    public void Select()
    {
        DrawCard();
    }

    private void DrawCard()
    {
        tableTurnManager.DrawCard();
    }
}
