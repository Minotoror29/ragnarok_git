using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private static MatchManager instance;
    public static MatchManager Instance => instance;

    private StateManager _stateManager;
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private EndMatchDisplay endMatchDisplay;

    [SerializeField] private int maxRounds = 3;

    [SerializeField] private Player[] kingdomsPrefabs;
    private List<Player> _players;
    [SerializeField] private Transform playerOverlaysParent;

    [SerializeField] private TitlesDisplay titlesDisplay;

    public RoundManager RoundManager { get { return roundManager; } }
    public EndMatchDisplay EndMatchDisplay { get { return endMatchDisplay; } }
    public int MaxRounds { get { return maxRounds; } }
    public List<Player> Players { get { return _players; } }
    public TitlesDisplay TitlesDisplay { get { return titlesDisplay; } }

    private void Awake()
    {
        instance = this;
    }

    public void Initialize(List<string> playerNames)
    {
        _stateManager = GetComponent<StateManager>();
        SpawnPlayers(playerNames);
        roundManager.Initialize(playerOverlaysParent);

        StartMatch(true);
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }

    private void SpawnPlayers(List<string> playerNames)
    {
        _players = new();

        for (int i = 0; i < playerNames.Count; i++)
        {
            Player newPlayer = Instantiate(kingdomsPrefabs[i], new Vector3(0, 0, 0), Quaternion.Euler(0, i * (360 / playerNames.Count), 0));
            _players.Add(newPlayer);
        }

        for (int i = 0; i < _players.Count; i++)
        {
            _players[i].Initialize(playerNames[i], playerOverlaysParent);
        }
    }

    public void StartMatch(bool firstMatch)
    {
        _stateManager.ChangeState(new MatchStartState(_stateManager, this, firstMatch));
    }

    public List<Player> DetermineMatchWinners(bool ragnarok)
    {
        List<Player> winners = new();

        if (!ragnarok)
        {
            int highestPoints = 0;

            foreach (Player player in _players)
            {
                if (player.RoundsWon > highestPoints)
                {
                    highestPoints = player.RoundsWon;
                }
            }

            foreach (Player player in _players)
            {
                if (player.RoundsWon == highestPoints)
                {
                    winners.Add(player);
                }
            }
        }

        return winners;
    }

    public List<Player> DeterminePlayerOrder(Player startingPlayer)
    {
        List<Player> order = new();

        for (int i = 0; i < _players.Count; i++)
        {
            order.Add(_players[(_players.IndexOf(startingPlayer) + i) % _players.Count]);
        }

        return order;
    }

    public Player GetRandomPlayer(List<Player> l)
    {
        int randomIndex = Random.Range(0, l.Count);

        return l[randomIndex];
    }

    public Player GetPlayerWithLessPoints()
    {
        List<Player> losers = new();

        int minimumPoints = 0;

        for (int i = 0; i < _players.Count; i++)
        {
            if (i == 0)
            {
                minimumPoints = _players[i].Points;
            } else
            {
                if (_players[i].Points < minimumPoints)
                {
                    minimumPoints = _players[i].Points;
                }
            }
        }

        foreach (Player player in _players)
        {
            if (player.Points == minimumPoints)
            {
                losers.Add(player);
            }
        }

        return GetRandomPlayer(losers);
    }

    public Player GetPlayerWhoWonLessRounds()
    {
        List<Player> losers = new();

        int minimumRoundsWon = 0;

        for (int i = 0; i < _players.Count; i++)
        {
            if (i == 0)
            {
                minimumRoundsWon = _players[i].RoundsWon;
            }
            else
            {
                if (_players[i].RoundsWon < minimumRoundsWon)
                {
                    minimumRoundsWon = _players[i].RoundsWon;
                }
            }
        }

        foreach (Player player in _players)
        {
            if (player.RoundsWon == minimumRoundsWon)
            {
                losers.Add(player);
            }
        }

        return GetRandomPlayer(losers);
    }
}
