using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private RoundManager roundManager;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        roundManager.Initialize();

        StartMatch();
    }

    private void StartMatch()
    {
        StartNewRound();
    }

    private void StartNewRound()
    {
        roundManager.StartRound();
    }
}
