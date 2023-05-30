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

    private List<Player> _opponents;

    private int _points;
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private TextMeshProUGUI nameText;

    public SelectionManager SelectionManager { get { return _selectionManager; } }
    public CinemachineVirtualCamera VCam { get { return vCam; } }
    public Canvas CardCanvas { get { return _cardCanvas; } }
    public CardDisplay CardDisplay { get { return _cardDisplay; } }
    public List<Player> Opponents { get { return _opponents; } }

    public void Initialize(TableTurnManager tableTurnManager, SelectionManager selectionManager, Canvas cardCanvas, CardDisplay cardDisplay, List<Player> players)
    {
        _stateManager = GetComponent<StateManager>();
        _tableTurnManager = tableTurnManager;
        _selectionManager = selectionManager;
        _cardCanvas = cardCanvas;
        _cardDisplay = cardDisplay;

        _opponents = new List<Player>();
        foreach (Player player in players)
        {
            _opponents.Add(player);
        }
        _opponents.Remove(this);

        _stateManager.ChangeState(new PlayerInactiveState(this));
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }

    public void StartPlayerTurn()
    {
        _stateManager.ChangeState(new PlayerDefaultState(this));
        nameText.color = Color.blue;
    }

    public void AddPoints(int value)
    {
        _points += value;
        _points = Mathf.Max(_points, 0);

        SetPointsText();
    }

    public void SetPoints(int value)
    {
        _points = value;

        SetPointsText();
    }

    public void DividePoints(float value)
    {
        _points = (int)(_points / value);

        SetPointsText();
    }

    public void SetPointsText()
    {
        pointsText.text = _points.ToString();
    }

    public void DrawCard(Card card)
    {
        _stateManager.ChangeState(new PlayerCardState(this, card));
    }

    public void PlayCard(EffectsManager effectsManager, Card card)
    {
        card.effect1.Activate(effectsManager, this);
        card.effect2.Activate(effectsManager, this);
    }

    public void EndPlayerTurn()
    {
        vCam.gameObject.SetActive(false);
        _stateManager.ChangeState(new PlayerInactiveState(this));
        nameText.color = Color.white;
    }
}
