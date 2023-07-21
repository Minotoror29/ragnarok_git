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

    [SerializeField] private CardDisplay cardDisplay;
    [SerializeField] private ValueDisplay valueDisplay;

    public RoundTableTurnState RoundState { get { return _roundState; } }
    public SelectionManager SelectionManager { get { return selectionManager; } }
    public List<Player> ActivePlayers { get { return _activePlayers; } }
    public Clock Clock { get { return _clock; } }
    public CardDisplay CardDisplay { get { return cardDisplay; } }
    public ValueDisplay ValueDisplay { get { return valueDisplay; } }

    public void Initialize(List<Player> players, Clock clock)
    {
        _stateManager = GetComponent<StateManager>();

        foreach (Player player in players)
        {
            player.Initialize(this, players);
        }

        _clock = clock;

        cardDisplay.Initialize(this);
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
        _activePlayers.Remove(player);

        foreach (Player p in _activePlayers)
        {
            if (p != player)
            {
                p.RemoveOpponent(player);
            }
        }
    }

    public Player GetNextPlayer(Player currentPlayer)
    {
        return _activePlayers[_activePlayers.IndexOf(currentPlayer) + 1];
    }
}
