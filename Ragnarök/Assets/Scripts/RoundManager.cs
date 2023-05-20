using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private List<Player> players;
    private int _currentPlayerIndex = 0;

    public void Initialize()
    {
        foreach (Player player in players)
        {
            player.Initialize(this);
        }
    }

    private void StartRound()
    {
        players[0].StartTurn();
    }

    public void NextPlayerTurn()
    {
        _currentPlayerIndex = (_currentPlayerIndex + 1) % players.Count;
        players[_currentPlayerIndex].StartTurn();
    }

    private void EndRound()
    {

    }
}
