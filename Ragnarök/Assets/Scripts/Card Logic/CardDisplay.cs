using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    private TableTurnManager _tableTurnManager;
    [SerializeField] private EffectsManager effectsManager;

    private Card _card;
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI cardEffect;

    public void Initialize(TableTurnManager tableTurnManager)
    {
        _tableTurnManager = tableTurnManager;
    }

    public void SetCard(Card card)
    {
        _card = card;

        cardName.text = card.name.ToUpper();
        cardEffect.text = card.effect1.description + " / " + card.effect2.description;
    }

    public void PlayCard()
    {
        _tableTurnManager.PlayCard(effectsManager, _card);
        _tableTurnManager.NextPlayerTurn();
    }

    public void DiscardCard()
    {
        _tableTurnManager.NextPlayerTurn();
    }
}
