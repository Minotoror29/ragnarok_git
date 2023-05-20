using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StateManager _stateManager;

    private RoundManager _roundManager;

    private Canvas _cardCanvas;

    //TESTS
    [SerializeField] private TextMeshProUGUI text;

    public void Initialize(RoundManager roundManager, Canvas cardCanvas)
    {
        _stateManager = GetComponent<StateManager>();
        _roundManager = roundManager;
        _cardCanvas = cardCanvas;
    }

    public void StartTurn()
    {
        _stateManager.ChangeState(new PlayerDefaultState(this));
        text.color = Color.blue;
    }

    public void DrawCard()
    {
        _stateManager.ChangeState(new PlayerCardState(this));
    }

    public void DisplayCardCanvas(bool display)
    {
        _cardCanvas.gameObject.SetActive(display);
    }

    private void NextTurn()
    {
        _roundManager.NextPlayerTurn();
    }

    public void EndTurn()
    {
        _stateManager.ChangeState(new PlayerInactiveState(this));
        text.color = Color.white;
    }
}
