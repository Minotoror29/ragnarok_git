using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private StateManager _stateManager;

    [SerializeField] private Canvas cardCanvas;

    [SerializeField] private List<Player> players;
    private int _currentPlayerIndex = 0;

    public void Initialize()
    {
        _stateManager = GetComponent<StateManager>();

        foreach (Player player in players)
        {
            player.Initialize(this, cardCanvas);
        }
    }

    public void StartRound()
    {
        _stateManager.ChangeState(new RoundPlayerState(this, players[0]));
    }

    public void DrawCard()
    {
        players[_currentPlayerIndex].DrawCard();
    }

    public void PlayCard()
    {
        NextPlayerTurn();
    }

    public void DiscardCard()
    {
        NextPlayerTurn();
    }

    public void NextPlayerTurn()
    {
        _currentPlayerIndex = (_currentPlayerIndex + 1) % players.Count;
        _stateManager.ChangeState(new RoundPlayerState(this, players[_currentPlayerIndex]));
    }

    private void EndRound()
    {

    }
}
