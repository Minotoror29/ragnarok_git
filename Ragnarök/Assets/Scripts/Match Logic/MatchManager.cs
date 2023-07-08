using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    private StateManager _stateManager;
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private Clock clock;
    [SerializeField] private EndMatchDisplay endMatchDisplay;

    private int _currentRound;
    [SerializeField] private int maxRounds = 3;

    [SerializeField] private List<Player> players;

    public int CurrentRound { get { return _currentRound; } }

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
        roundManager.Initialize(this, clock, players);
        clock.Initialize(roundManager);

        StartMatch();
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
        roundManager.UpdateLogic();
    }

    private void StartMatch()
    {
        Debug.Log("Start new match");

        _stateManager.ChangeState(new MatchPlayState());

        _currentRound = 0;
        StartNewRound();
    }

    public void StartNewRound()
    {
        if (_currentRound == maxRounds)
        {
            EndMatch();
            return;
        }

        _currentRound++;
        Debug.Log("Start round " + _currentRound);

        if (_currentRound == 1)
        {
            roundManager.StartRound(GetRandomPlayer(players));
        } else
        {
            roundManager.StartRound(GetPlayerWithLessPoints(players));
        }
    }

    private void EndMatch()
    {
        Debug.Log("End of the match");

        roundManager.StateManager.ChangeState(new RoundPlayState());
        _stateManager.ChangeState(new MatchEndState(endMatchDisplay, DetermineMatchWinners(players)));
    }

    private List<Player> DetermineMatchWinners(List<Player> l)
    {
        List<Player> winners = new();

        int highestPoints = 0;

        foreach (Player player in l)
        {
            if (player.RoundsWon > highestPoints)
            {
                highestPoints = player.RoundsWon;
            }
        }

        foreach (Player player in l)
        {
            if (player.RoundsWon == highestPoints)
            {
                winners.Add(player);
            }
        }

        return winners;
    }

    private Player GetRandomPlayer(List<Player> l)
    {
        int randomIndex = Random.Range(0, l.Count);

        return l[randomIndex];
    }

    private Player GetPlayerWithLessPoints(List<Player> l)
    {
        List<Player> losers = new();

        int minimumPoints = 0;

        for (int i = 0; i < l.Count; i++)
        {
            if (i == 0)
            {
                minimumPoints = l[i].Points;
            } else
            {
                if (l[i].Points < minimumPoints)
                {
                    minimumPoints = l[i].Points;
                }
            }
        }

        foreach (Player player in l)
        {
            if (player.Points == minimumPoints)
            {
                losers.Add(player);
            }
        }

        return GetRandomPlayer(losers);
    }
}
