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
    [SerializeField] private EndRoundDisplay endRoundDisplay;

    [SerializeField] private List<Player> players;

    public RoundManager RoundManager { get { return roundManager; } }
    public Clock Clock { get { return clock; } }
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
    }

    private void StartMatch()
    {
        Debug.Log("Start new match");

        _currentRound = 0;
        StartNewRound();
    }

    public void StartNewRound()
    {
        _currentRound++;
        Debug.Log("Start round " + _currentRound);

        if (_currentRound == 1)
        {
            Player player = GetRandomPlayer(players);

            roundManager.StartRound(player);

            //_stateManager.ChangeState(new TableTurnTransitionState(_stateManager, this, player));
        } else
        {
            Player player = GetPlayerWithLessPoints();

            roundManager.StartRound(player);

            //_stateManager.ChangeState(new TableTurnTransitionState(_stateManager, this, player));
        }
    }

    private void EndMatch()
    {
        Debug.Log("End of the match");
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

    public Player GetPlayerWithLessPoints(List<Player> l = null)
    {
        //Same thing as
        // if (l == null) { l = players }
        l ??= players;

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

    public Player GetNextPlayer(Player currentPlayer)
    {
        int playerIndex = roundManager.ActivePlayers.IndexOf(currentPlayer) + 1;

        playerIndex %= roundManager.ActivePlayers.Count;

        return roundManager.ActivePlayers[playerIndex];
    }

    public void DisplayEndRoundCanvas(bool display, RoundEndState state = null)
    {
        endRoundDisplay.gameObject.SetActive(display);
        if (!display) return;
        endRoundDisplay.Initialize(state);
        endRoundDisplay.SetTitle(_currentRound);
        endRoundDisplay.SetWinnerText(roundManager.DetermineRoundWinners(roundManager.ActivePlayers));
        endRoundDisplay.SetButton(_currentRound == maxRounds);
    }

    public void DisplayEndMatchCanvas(bool display)
    {
        endMatchDisplay.gameObject.SetActive(display);
        if (!display) return;
        endMatchDisplay.SetWinnersText(DetermineMatchWinners(roundManager.ActivePlayers));
    }
}
