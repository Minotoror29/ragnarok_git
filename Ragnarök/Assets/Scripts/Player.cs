using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private RoundManager _roundManager;

    //TESTS
    [SerializeField] private TextMeshProUGUI text;

    public void Initialize(RoundManager roundManager)
    {
        _roundManager = roundManager;
    }

    public void StartTurn()
    {
        text.color = Color.blue;
    }

    private void EndTurn()
    {
        text.color = Color.white;
        _roundManager.NextPlayerTurn();
    }
}
