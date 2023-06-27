using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, ISelectable
{
    private StateManager _stateManager;
    private TableTurnManager _tableTurnManager;
    private SelectionManager _selectionManager;

    [SerializeField] private CinemachineVirtualCamera vCam;

    private Canvas _cardCanvas;
    private CardDisplay _cardDisplay;
    private ValueDisplay _valueDisplay;

    private List<Player> _opponents;

    private int _points;
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private TextMeshProUGUI nameText;

    [HideInInspector] public bool mustSkipNextTurn = false;
    [HideInInspector] public bool opponentsVoteForCard = false;

    public StateManager StateManager { get { return _stateManager; } }
    public TableTurnManager TableTurnManager { get { return _tableTurnManager; } }
    public SelectionManager SelectionManager { get { return _selectionManager; } }
    public CinemachineVirtualCamera VCam { get { return vCam; } }
    public Canvas CardCanvas { get { return _cardCanvas; } }
    public CardDisplay CardDisplay { get { return _cardDisplay; } }
    public ValueDisplay ValueDisplay { get { return _valueDisplay; } }
    public List<Player> Opponents { get { return _opponents; } }
    public int Points { get { return _points; } }

    public void Initialize(TableTurnManager tableTurnManager, SelectionManager selectionManager, Canvas cardCanvas, CardDisplay cardDisplay, ValueDisplay valueDisplay, List<Player> players)
    {
        _stateManager = GetComponent<StateManager>();
        _tableTurnManager = tableTurnManager;
        _selectionManager = selectionManager;
        _cardCanvas = cardCanvas;
        _cardDisplay = cardDisplay;
        _valueDisplay = valueDisplay;

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

        if (mustSkipNextTurn)
        {
            _tableTurnManager.NextPlayerTurn();
            mustSkipNextTurn = false;
        }
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
        //card.effect1.Activate(effectsManager, this);
        //card.effect2.Activate(effectsManager, this);

        _stateManager.ChangeState(new PlayerEffectState(this, card.effect1, card.effect2, effectsManager));
    }

    public void EndPlayerTurn()
    {
        vCam.gameObject.SetActive(false);
        _stateManager.ChangeState(new PlayerInactiveState(this));
        nameText.color = Color.white;
    }

    public void Select(PlayerState state)
    {
        state.SelectPlayer(this);
    }
}
