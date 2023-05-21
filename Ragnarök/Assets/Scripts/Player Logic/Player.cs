using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private StateManager _stateManager;
    private TableTurnManager _tableTurnManager;
    private SelectionManager _selectionManager;

    [SerializeField] private CinemachineVirtualCamera vCam;

    private Canvas _cardCanvas;
    private CardDisplay _cardDisplay;

    public CinemachineVirtualCamera VCam { get { return vCam; } }
    public Canvas CardCanvas { get { return _cardCanvas; } }
    public CardDisplay CardDisplay { get { return _cardDisplay; } }

    //TESTS
    [SerializeField] private TextMeshProUGUI text;

    public void Initialize(TableTurnManager tableTurnManager, SelectionManager selectionManager, Canvas cardCanvas, CardDisplay cardDisplay)
    {
        _stateManager = GetComponent<StateManager>();
        _tableTurnManager = tableTurnManager;
        _selectionManager = selectionManager;
        _cardCanvas = cardCanvas;
        _cardDisplay = cardDisplay;

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
        _selectionManager.Enable();
    }

    public void UpdateSelection()
    {
        _selectionManager.UpdateLogic();
    }

    public void DisableSelection()
    {
        _selectionManager.Disable();
    }

    public void DrawCard(Card card)
    {
        _stateManager.ChangeState(new PlayerCardState(this, card));
    }

    public void EndPlayerTurn()
    {
        vCam.gameObject.SetActive(false);
        _stateManager.ChangeState(new PlayerInactiveState(this));
        text.color = Color.white;
    }
}
