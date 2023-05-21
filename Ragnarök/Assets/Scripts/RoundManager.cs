using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private TableTurnManager tableTurnManager;

    [SerializeField] private Clock clock;
    [SerializeField] private int startHours = 0;

    public void Initialize()
    {
        tableTurnManager.Initialize(this, clock);
        clock.Initialize(this);
    }

    public void UpdateLogic()
    {
        tableTurnManager.UpdateLogic();
    }

    public void StartRound()
    {
        clock.SetHour(startHours);
        tableTurnManager.StartTableTurn();
    }
}
