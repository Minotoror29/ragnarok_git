using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private TableTurnManager tableTurnManager;

    private Clock _clock;
    [SerializeField] private int startHours = 0;

    [SerializeField] private List<Player> players;
    [SerializeField] private int playersStartPoints = 4;

    public void Initialize(Clock clock)
    {
        _clock = clock;

        tableTurnManager.Initialize(this, _clock, players);
    }

    public void UpdateLogic()
    {
        tableTurnManager.UpdateLogic();
    }

    public void StartRound()
    {
        _clock.SetHour(startHours);
        foreach (Player player in players)
        {
            player.SetPoints(playersStartPoints);
        }
        tableTurnManager.StartTableTurn();
    }
}
