using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    private Card _card;
    [SerializeField] private TextMeshProUGUI cardEffect;

    public void Initialize(Card card)
    {
        _card = card;

        cardEffect.text = card.effect1.description + " / " + card.effect2.description;
    }

    private void PlayCard()
    {

    }

    private void DiscardCard()
    {

    }
}
