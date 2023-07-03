using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private StateManager _stateManager;
    private MatchManager _matchManager;
    [SerializeField] private TableTurnManager tableTurnManager;

    private Clock _clock;
    [SerializeField] private int startHours = 0;

    [SerializeField] private List<Player> players;
    [SerializeField] private int playersStartPoints = 4;

    [SerializeField] private int maxTableTurns = 5;
    private int _currentTableTurn;

    [SerializeField] private EndRoundDisplay endRoundDisplay;

    public void Initialize(MatchManager matchManager, Clock clock)
    {
        _stateManager = GetComponent<StateManager>();
        _matchManager = matchManager;
        _clock = clock;

        tableTurnManager.Initialize(this, _clock, players);
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();

        tableTurnManager.UpdateLogic();
    }

    public void StartRound()
    {
        _stateManager.ChangeState(new RoundPlayState());

        _clock.SetHour(startHours);
        foreach (Player player in players)
        {
            player.SetPoints(playersStartPoints);
        }

        _currentTableTurn = 0;
        StartNewTableTurn();
    }

    public void StartNewTableTurn()
    {
        if (_currentTableTurn == maxTableTurns)
        {
            EndRound();
            return;
        }

        _currentTableTurn++;
        Debug.Log("Start table turn " + _currentTableTurn);
        tableTurnManager.StartTableTurn();
    }

    private void EndRound()
    {
        _stateManager.ChangeState(new RoundEndState(endRoundDisplay, _matchManager.CurrentRound, DetermineWinners(players)));
    }

    private List<Player> DetermineWinners(List<Player> players)
    {
        List<Player> winners = new();

        int highestPoints = 0;

        foreach (Player player in players)
        {
            if (player.Points > highestPoints)
            {
                highestPoints = player.Points;
            }
        }

        foreach (Player player in players)
        {
            if (player.Points == highestPoints)
            {
                winners.Add(player);
            }
        }

        return winners;
    }
}
