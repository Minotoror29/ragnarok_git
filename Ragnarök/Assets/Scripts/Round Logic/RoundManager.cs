using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private StateManager _stateManager;

    private MatchRoundState _matchState;
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private Clock clock;
    [SerializeField] private Deck deck;

    [SerializeField] private CardDisplay cardDisplay;

    private List<Player> _activePlayers;
    [SerializeField] private int playersStartPoints = 4;

    [SerializeField] private int maxTableTurns = 5;

    [SerializeField] private EndRoundDisplay endRoundDisplay;
    [SerializeField] private TableTurnsDisplay tableTurnsDisplay;

    public MatchRoundState MatchRoundState { get { return _matchState; } }
    public TableTurnManager TableTurnManager { get { return tableTurnManager; } }
    public Clock Clock { get { return clock; } }
    public Deck Deck { get { return deck; } }
    public List<Player> ActivePlayers { get { return _activePlayers; } }
    public int PlayersStartPoints { get { return playersStartPoints; } }
    public int MaxTableTurns { get { return maxTableTurns; } }
    public EndRoundDisplay EndRoundDisplay { get { return endRoundDisplay; } }
    public TableTurnsDisplay TableTurnsDisplay { get { return tableTurnsDisplay; } }

    public void Initialize(List<Player> players)
    {
        _stateManager = GetComponent<StateManager>();

        cardDisplay.Initialize(this);
        tableTurnManager.Initialize(players, clock, cardDisplay);
    }

    public void Updatelogic()
    {
        _stateManager.UpdateLogic();
    }

    public void StartRound(MatchRoundState matchState, int roundNumber, List<Player> players)
    {
        _matchState = matchState;
        _activePlayers = new();
        foreach (Player player in players)
        {
            _activePlayers.Add(player);
        }

        _stateManager.ChangeState(new RoundStartState(_stateManager, this, roundNumber));
    }

    public List<Player> DetermineRoundWinners(bool ragnarok)
    {
        List<Player> winners = new();

        if (!ragnarok)
        {
            int highestPoints = 0;

            foreach (Player player in _activePlayers)
            {
                if (player.Points > highestPoints)
                {
                    highestPoints = player.Points;
                }
            }

            foreach (Player player in _activePlayers)
            {
                if (player.Points == highestPoints)
                {
                    winners.Add(player);
                    player.WinRound();
                }
            }
        }

        return winners;
    }

    public void EliminatePlayers(List<Player> playersToEliminate)
    {
        foreach (Player player in playersToEliminate)
        {
            if (_activePlayers.Contains(player))
            {
                _activePlayers.Remove(player);
                foreach (Player p in _activePlayers)
                {
                    if (p != player)
                    {
                        p.RemoveOpponent(player);
                    }
                }
                tableTurnManager.EliminatePlayer(player);
            }
        }
    }
}
