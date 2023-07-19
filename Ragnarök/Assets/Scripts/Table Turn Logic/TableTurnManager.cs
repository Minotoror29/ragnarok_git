using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnManager : MonoBehaviour
{
    [SerializeField] private StateManager _stateManager;
    [SerializeField] private SelectionManager selectionManager;
    private RoundManager _roundManager;

    [SerializeField] private CardDisplay cardDisplay;
    [SerializeField] private ValueDisplay valueDisplay;
    private Clock _clock;

    private List<Player> _players;
    private int _currentPlayerIndex = 0;
    private int _startingPlayerIndex;

    public List<Player> Players { get { return _players; } }

    public void Initialize(RoundManager roundManager, Clock clock, List<Player> players)
    {
        _roundManager = roundManager;

        _clock = clock;
        _players = players;

        foreach (Player player in _players)
        {
            player.Initialize(this, selectionManager, cardDisplay, valueDisplay, _players);
        }

        cardDisplay.Initialize(this);
    }

    public void StartTableTurn(Player player)
    {
        _clock.AddHours(1);

        _startingPlayerIndex = _players.IndexOf(player);
        _currentPlayerIndex = _startingPlayerIndex;
    }

    public void NextPlayerTurn()
    {
        _currentPlayerIndex ++;
        _currentPlayerIndex %= _players.Count;
        if (_currentPlayerIndex == _startingPlayerIndex)
        {
            _roundManager.StartNewTableTurn();
            return;
        }
    }

    public void StartPlayerTurn()
    {
    }

    public void EndTableTurn()
    {

    }

    public void EliminatePlayer(Player player)
    {
        _roundManager.EliminatePlayer(player);
    }
}
