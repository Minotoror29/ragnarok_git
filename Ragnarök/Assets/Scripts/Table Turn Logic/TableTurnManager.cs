using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnManager : MonoBehaviour
{
    private StateManager _stateManager;
    private RoundTableTurnState _roundState;
    [SerializeField] private SelectionManager selectionManager;

    private List<Player> _activePlayers;

    private Clock _clock;
    private Deck _deck;

    private CardDisplay _cardDisplay;
    [SerializeField] private ValueDisplay valueDisplay;

    private CinemachineVirtualCamera _topCam;

    public RoundTableTurnState RoundState { get { return _roundState; } }
    public SelectionManager SelectionManager { get { return selectionManager; } }
    public List<Player> ActivePlayers { get { return _activePlayers; } }
    public Clock Clock { get { return _clock; } }
    public Deck Deck { get { return _deck; } }
    public CardDisplay CardDisplay { get { return _cardDisplay; } }
    public ValueDisplay ValueDisplay { get { return valueDisplay; } }
    public CinemachineVirtualCamera TopCam { get { return _topCam; } }

    public void Initialize(Clock clock, Deck deck, CardDisplay cardDisplay, CinemachineVirtualCamera topCam)
    {
        _stateManager = GetComponent<StateManager>();

        _clock = clock;
        _deck = deck;

        _cardDisplay = cardDisplay;

        _topCam = topCam;
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }

    public void StartTableTurn(RoundTableTurnState roundState)
    {
        _roundState = roundState;

        _stateManager.ChangeState(new TableTurnStartState(_stateManager, this));
    }

    public void SetActivePlayers(List<Player> players)
    {
        _activePlayers = new();
        foreach (Player player in players)
        {
            _activePlayers.Add(player);
        }
    }

    public void EliminatePlayer(Player player)
    {
        if (_activePlayers.Contains(player))
        {
            _activePlayers.Remove(player);
        }
    }

    public Player GetNextPlayer(Player currentPlayer)
    {
        return _activePlayers[_activePlayers.IndexOf(currentPlayer) + 1];
    }
}
