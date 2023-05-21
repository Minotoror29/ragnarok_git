using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StateManager _stateManager;
    private TableTurnManager _tableTurnManager;
    private SelectionManager _selectionManager;

    private Canvas _cardCanvas;

    //TESTS
    [SerializeField] private TextMeshProUGUI text;

    public void Initialize(TableTurnManager tableTurnManager, SelectionManager selectionManager, Canvas cardCanvas)
    {
        _stateManager = GetComponent<StateManager>();
        _tableTurnManager = tableTurnManager;
        _selectionManager = selectionManager;
        _cardCanvas = cardCanvas;

        _stateManager.ChangeState(new PlayerInactiveState(this));
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }

    public void StartPlayerTurn()
    {
        _stateManager.ChangeState(new PlayerDefaultState(this));
        text.color = Color.blue;
    }

    public void EnableSelection()
    {
        _selectionManager.Initialize();
    }

    public void UpdateSelection()
    {
        _selectionManager.UpdateLogic();
    }

    public void DisableSelection()
    {
        _selectionManager.Disable();
    }

    public void DrawCard()
    {
        _stateManager.ChangeState(new PlayerCardState(this));
    }

    public void DisplayCardCanvas(bool display)
    {
        _cardCanvas.gameObject.SetActive(display);
    }

    public void EndPlayerTurn()
    {
        _stateManager.ChangeState(new PlayerInactiveState(this));
        text.color = Color.white;
    }
}
