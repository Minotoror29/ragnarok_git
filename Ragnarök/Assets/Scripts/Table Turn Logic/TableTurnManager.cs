using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnManager : MonoBehaviour
{
    private StateManager _stateManager;
    [SerializeField] private SelectionManager selectionManager;

    [SerializeField] private List<Player> activePlayers;

    [SerializeField] private Clock clock;

    [SerializeField] private CardDisplay cardDisplay;
    [SerializeField] private ValueDisplay valueDisplay;

    public SelectionManager SelectionManager { get { return selectionManager; } }
    public List<Player> ActivePlayers { get { return activePlayers; } }
    public Clock Clock { get { return clock; } }
    public CardDisplay CardDisplay { get { return cardDisplay; } }
    public ValueDisplay ValueDisplay { get { return valueDisplay; } }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _stateManager = GetComponent<StateManager>();

        foreach (Player player in activePlayers)
        {
            player.Initialize(this, activePlayers);
        }
        cardDisplay.Initialize(this);

        _stateManager.ChangeState(new TableTurnStartState(_stateManager, this));
    }

    private void Update()
    {
        UpdateLogic();
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }

    public void EliminatePlayer(Player player)
    {
        activePlayers.Remove(player);

        foreach (Player p in activePlayers)
        {
            if (p != player)
            {
                p.RemoveOpponent(player);
            }
        }
    }

    public Player GetNextPlayer(Player currentPlayer)
    {
        return activePlayers[activePlayers.IndexOf(currentPlayer) + 1];
    }
}
