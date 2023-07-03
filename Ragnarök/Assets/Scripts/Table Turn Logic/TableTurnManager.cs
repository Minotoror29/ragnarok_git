using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnManager : MonoBehaviour
{
    private StateManager _stateManager;
    [SerializeField] private SelectionManager selectionManager;
    private RoundManager _roundManager;

    [SerializeField] private Canvas cardCanvas;
    [SerializeField] private CardDisplay cardDisplay;
    [SerializeField] private ValueDisplay valueDisplay;
    private Clock _clock;

    private List<Player> _players;
    private int _currentPlayerIndex = 0;

    public void Initialize(RoundManager roundManager, Clock clock, List<Player> players)
    {
        _stateManager = GetComponent<StateManager>();
        _roundManager = roundManager;

        _clock = clock;
        _players = players;

        foreach (Player player in _players)
        {
            player.Initialize(this, selectionManager, cardCanvas, cardDisplay, valueDisplay, _players);
        }

        cardDisplay.Initialize(this, _players);
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();

        foreach (Player player in _players)
        {
            player.UpdateLogic();
        }
    }

    public void StartTableTurn()
    {
        _clock.AddHours(1);

        _currentPlayerIndex = 0;
        _stateManager.ChangeState(new TableTurnTransitionState(this, _players[_currentPlayerIndex]));
    }

    public void PlayCard(EffectsManager effectsManager, Card card)
    {
        _players[_currentPlayerIndex].PlayCard(effectsManager, card);
    }

    public void NextPlayerTurn()
    {
        _currentPlayerIndex ++;
        if (_currentPlayerIndex == _players.Count)
        {
            _roundManager.StartNewTableTurn();
            return;
        }

        _stateManager.ChangeState(new TableTurnTransitionState(this, _players[_currentPlayerIndex]));
    }

    public void StartPlayerTurn()
    {
        _stateManager.ChangeState(new TableTurnPlayerState(this, _players[_currentPlayerIndex]));
    }

    public void EndTableTurn()
    {

    }
}
