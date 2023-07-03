using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour
{
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private Clock clock;

    private int _currentRound;
    [SerializeField] private int maxRounds = 3;

    public int CurrentRound { get { return _currentRound; } }

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
        roundManager.Initialize(this, clock);
        clock.Initialize(this);

        StartMatch();
    }

    public void UpdateLogic()
    {
        roundManager.UpdateLogic();
    }

    private void StartMatch()
    {
        Debug.Log("Start new match");

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
        Debug.Log("Start round " + _currentRound);
        roundManager.StartRound();
    }

    private void EndMatch()
    {
        Debug.Log("End of the match");
    }
}
