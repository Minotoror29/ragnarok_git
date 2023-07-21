using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private StateManager _stateManager;
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private EndMatchDisplay endMatchDisplay;

    [SerializeField] private int maxRounds = 3;

    [SerializeField] private List<Player> players;

    public RoundManager RoundManager { get { return roundManager; } }
    public EndMatchDisplay EndMatchDisplay { get { return endMatchDisplay; } }
    public int MaxRounds { get { return maxRounds; } }
    public List<Player> Players { get { return players; } }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateLogic();
    }

    public void Initialize()
    {
        _stateManager = GetComponent<StateManager>();
        roundManager.Initialize(players);

        StartMatch();
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }

    private void StartMatch()
    {
        _stateManager.ChangeState(new MatchStartState(_stateManager, this));
    }

    public List<Player> DetermineMatchWinners()
    {
        List<Player> winners = new();

        int highestPoints = 0;

        foreach (Player player in players)
        {
            if (player.RoundsWon > highestPoints)
            {
                highestPoints = player.RoundsWon;
            }
        }

        foreach (Player player in players)
        {
            if (player.RoundsWon == highestPoints)
            {
                winners.Add(player);
            }
        }

        return winners;
    }

    public List<Player> DeterminePlayerOrder(Player startingPlayer)
    {
        List<Player> order = new();

        for (int i = 0; i < players.Count; i++)
        {
            order.Add(players[(players.IndexOf(startingPlayer) + i) % players.Count]);
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

        for (int i = 0; i < players.Count; i++)
        {
            if (i == 0)
            {
                minimumPoints = players[i].Points;
            } else
            {
                if (players[i].Points < minimumPoints)
                {
                    minimumPoints = players[i].Points;
                }
            }
        }

        foreach (Player player in players)
        {
            if (player.Points == minimumPoints)
            {
                losers.Add(player);
            }
        }

        return GetRandomPlayer(losers);
    }
}
