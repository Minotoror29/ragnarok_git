using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnManager : MonoBehaviour
{
    private StateManager _stateManager;
    [SerializeField] private SelectionManager selectionManager;
    private RoundManager _roundManager;

    [SerializeField] private Canvas cardCanvas;
    private Clock _clock;

    [SerializeField] private List<Player> players;
    private int _currentPlayerIndex = 0;

    public void Initialize(RoundManager roundManager, Clock clock)
    {
        _stateManager = GetComponent<StateManager>();
        _roundManager = roundManager;

        _clock = clock;

        foreach (Player player in players)
        {
            player.Initialize(this, selectionManager, cardCanvas);
        }
    }

    public void UpdateLogic()
    {
        foreach (Player player in players)
        {
            player.UpdateLogic();
        }
    }

    public void StartTableTurn()
    {
        _clock.AddHour(1);

        _currentPlayerIndex = 0;
        _stateManager.ChangeState(new TableTurnPlayerState(this, players[_currentPlayerIndex]));
    }

    public void DrawCard()
    {
        players[_currentPlayerIndex].DrawCard();
    }

    public void PlayCard()
    {
        NextPlayerTurn();
    }

    public void DiscardCard()
    {
        NextPlayerTurn();
    }

    public void NextPlayerTurn()
    {
        _currentPlayerIndex ++;
        if (_currentPlayerIndex == players.Count)
        {
            StartTableTurn();
        }

        _stateManager.ChangeState(new TableTurnPlayerState(this, players[_currentPlayerIndex]));
    }
}
