using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private Clock clock;

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
        roundManager.Initialize(clock);
        clock.Initialize(this);

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

    public void StartNewRound()
    {
        if (_currentRound == maxRounds)
        {
            EndMatch();
            return;
        }

        _currentRound++;
        roundManager.StartRound();
    }

    private void EndMatch()
    {
        Debug.Log("End of the match");
    }
}
