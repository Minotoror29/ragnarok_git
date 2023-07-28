using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnsDisplay : MonoBehaviour
{
    [SerializeField] private List<TableTurnIndicator> indicators;

    public void StartTableTurn(int tableTurnIndex)
    {
        for (int i = 0; i < indicators.Count; i++)
        {
            if (i == tableTurnIndex - 1)
            {
                indicators[i].SetActive();
            } else
            {
                indicators[i].SetInactive();
            }
        }
    }
}
