using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private RoundManager roundManager;

    private int _currentRound;
    [SerializeField] private int maxRounds = 3;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateLogic();
    }

    public void Initialize()
    {
        roundManager.Initialize();

        StartMatch();
    }

    public void UpdateLogic()
    {
        roundManager.UpdateLogic();
    }

    private void StartMatch()
    {
        _currentRound = 0;
        StartNewRound();
    }

    private void StartNewRound()
    {
        if (_currentRound == maxRounds)
        {
            EndMatch();
        }

        _currentRound++;
        roundManager.StartRound();
    }

    private void EndMatch()
    {

    }
}
