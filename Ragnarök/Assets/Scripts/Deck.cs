using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour, ISelectable
{
    [SerializeField] private RoundManager roundManager;

    public void Select()
    {
        DrawCard();
    }

    private void DrawCard()
    {
        roundManager.DrawCard();
    }
}
