using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private StateManager _stateManager;
    private MatchManager _matchManager;
    [SerializeField] private TableTurnManager tableTurnManager;

    private Clock _clock;
    [SerializeField] private int startHours = 0;

    private List<Player> _players;
    private List<Player> _activePlayers;
    [SerializeField] private int playersStartPoints = 4;
    private Player _startingPlayer;

    [SerializeField] private int maxTableTurns = 5;
    private int _currentTableTurn;

    [SerializeField] private EndRoundDisplay endRoundDisplay;

    public StateManager StateManager { get { return _stateManager; } }

    public void Initialize(MatchManager matchManager, Clock clock, List<Player> players)
    {
        //_stateManager = GetComponent<StateManager>();
        _matchManager = matchManager;
        _clock = clock;
        _players = players;

        tableTurnManager.Initialize(this, _clock, _players);
    }

    public void UpdateLogic()
    {
        //_stateManager.UpdateLogic();

        tableTurnManager.UpdateLogic();
    }

    public void StartRound(Player startingPlayer)
    {
        _stateManager.ChangeState(new RoundPlayState());

        _clock.SetHour(startHours);
        foreach (Player player in _players)
        {
            player.SetPoints(playersStartPoints);
            player.IsDead = false;
            player.NameText.color = Color.white;
        }

        _activePlayers = _players;
        _startingPlayer = startingPlayer;
        _currentTableTurn = 0;
        StartNewTableTurn();
    }

    public void StartNewTableTurn()
    {
        if (_currentTableTurn == maxTableTurns)
        {
            EndRound(false);
            return;
        }

        _currentTableTurn++;
        Debug.Log("Start table turn " + _currentTableTurn);
        tableTurnManager.StartTableTurn(_startingPlayer);
    }

    public void EndRound(bool ragnarok)
    {
        List<Player> winners = new();
        if (!ragnarok)
        {
            winners = DetermineWinners(_activePlayers);
        }

        _stateManager.ChangeState(new RoundEndState(endRoundDisplay, _matchManager.CurrentRound, winners));
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
                player.WinRound();
            }
        }

        return winners;
    }

    public void EliminatePlayer(Player player)
    {
        _activePlayers.Remove(player);

        if (_activePlayers.Count == 1)
        {
            EndRound(false);
        } else if (_activePlayers.Count == 0)
        {
            EndRound(true);
        }
    }
}
