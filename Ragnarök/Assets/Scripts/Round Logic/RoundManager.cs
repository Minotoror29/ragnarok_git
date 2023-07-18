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
    public List<Player> ActivePlayers { get { return _activePlayers; } }
    public int MaxTableTurns { get { return maxTableTurns; } }
    public int CurrentTableTurn { get { return _currentTableTurn; } }

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
        //_stateManager.ChangeState(new RoundPlayState(_stateManager));

        _clock.SetHour(startHours);
        foreach (Player player in _players)
        {
            player.SetPoints(playersStartPoints);
            player.IsDead = false;
            player.NameText.color = Color.white;
        }

        _activePlayers = new();

        for (int i = 0; i < _players.Count; i++)
        {
            int playerIndex = (_players.IndexOf(startingPlayer) + i) % _players.Count;

            _activePlayers.Add(_players[playerIndex]);
        }

        _startingPlayer = startingPlayer;
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
        tableTurnManager.StartTableTurn(_startingPlayer);
    }

    public void EndRound()
    {
        //List<Player> winners = new();
        //if (!ragnarok)
        //{
        //    winners = DetermineRoundWinners(_activePlayers);
        //}

        //_stateManager.ChangeState(new RoundEndState(_stateManager, endRoundDisplay, _matchManager.CurrentRound, winners));
    }

    public List<Player> DetermineRoundWinners(List<Player> players)
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
    }
}
