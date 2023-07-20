using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    private PlayerState _currentState;

    public void ChangeState(PlayerState nextState)
    {
        if (_currentState != null)
        {
            _currentState.Exit();
        }
        _currentState = nextState;
        _currentState.Enter();
    }

    public void StartPlayerTurn()
    {
        _currentState.StartPlayerTurn();
    }

    public void EndPlayerTurn()
    {
        _currentState.EndPlayerTurn();
    }

    public void CheckPoints(int points)
    {
        _currentState.CheckPoints(points);
    }
}
