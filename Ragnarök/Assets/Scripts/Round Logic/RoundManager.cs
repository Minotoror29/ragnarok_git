using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private StateManager _stateManager;

    private MatchRoundState _matchState;
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private Clock clock;

    private List<Player> _players;
    [SerializeField] private int playersStartPoints = 4;

    [SerializeField] private int maxTableTurns = 5;

    [SerializeField] private EndRoundDisplay endRoundDisplay;

    public MatchRoundState MatchRoundState { get { return _matchState; } }
    public TableTurnManager TableTurnManager { get { return tableTurnManager; } }
    public Clock Clock { get { return clock; } }
    public List<Player> Players { get { return _players; } }
    public int PlayersStartPoints { get { return playersStartPoints; } }
    public int MaxTableTurns { get { return maxTableTurns; } }
    public EndRoundDisplay EndRoundDisplay { get { return endRoundDisplay; } }

    public void Initialize(List<Player> players)
    {
        _stateManager = GetComponent<StateManager>();

        tableTurnManager.Initialize(players, clock);
    }

    public void Updatelogic()
    {
        _stateManager.UpdateLogic();
    }

    public void StartRound(MatchRoundState matchState, int roundNumber, List<Player> players)
    {
        _matchState = matchState;
        _players = players;

        _stateManager.ChangeState(new RoundStartState(_stateManager, this, roundNumber));
    }

    public List<Player> DetermineRoundWinners()
    {
        List<Player> winners = new();

        int highestPoints = 0;

        foreach (Player player in _players)
        {
            if (player.Points > highestPoints)
            {
                highestPoints = player.Points;
            }
        }

        foreach (Player player in _players)
        {
            if (player.Points == highestPoints)
            {
                winners.Add(player);
                player.WinRound();
            }
        }

        return winners;
    }
}
