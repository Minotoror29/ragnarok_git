using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTableTurnState : RoundState
{
    private int _currentTableTurn;

    public RoundTableTurnState(StateManager stateManager, RoundManager roundManager, int roundNumber, int previoustableTurnIndex) : base(stateManager, roundManager, roundNumber)
    {
        _currentTableTurn = previoustableTurnIndex + 1;
    }

    public override void Enter()
    {
        _roundManager.TableTurnManager.SetActivePlayers(_roundManager.ActivePlayers);
        _roundManager.TableTurnManager.StartTableTurn(this);
        _roundManager.TableTurnsDisplay.StartTableTurn(_currentTableTurn);
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
        _roundManager.TableTurnManager.UpdateLogic();
    }

    public void TableTurnEnd()
    {
        if (_currentTableTurn == _roundManager.MaxTableTurns)
        {
            _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber, false));
        } else
        {
            _stateManager.ChangeState(new RoundTableTurnState(_stateManager, _roundManager, _roundNumber, _currentTableTurn));
        }
    }

    public bool IsRoundOver()
    {
        List<Player> playersToEliminate = new();
        foreach (Player player in _roundManager.ActivePlayers)
        {
            if (player.Points == 0)
            {
                playersToEliminate.Add(player);
            }
        }
        _roundManager.EliminatePlayers(playersToEliminate);

        if (_roundManager.Clock.IsAtMidnight() ||
            _roundManager.ActivePlayers.Count == 0)
        {
            _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber, true));
            return true;
        }
        else if (_roundManager.ActivePlayers.Count == 1)
        {
            _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber, false));
            return true;
        }
        else
        {
            SetPlayersWealth();
            return false;
        }
    }

    public void SetPlayersWealth()
    {
        int minimumPoints = _roundManager.ActivePlayers[0].Points;
        int maximumPoints = _roundManager.ActivePlayers[0].Points;

        for (int i = 1; i < _roundManager.ActivePlayers.Count; i++)
        {
            if (_roundManager.ActivePlayers[i].Points < minimumPoints)
            {
                minimumPoints = _roundManager.ActivePlayers[i].Points;
            } else if (_roundManager.ActivePlayers[i].Points > maximumPoints)
            {
                maximumPoints = _roundManager.ActivePlayers[i].Points;
            }
        }

        foreach (Player player in _roundManager.ActivePlayers)
        {
            if (player.Points == minimumPoints)
            {
                player.Wealth = Wealth.Poor;
            } else if (player.Points == maximumPoints)
            {
                player.Wealth = Wealth.Rich;
            } else
            {
                player.Wealth = Wealth.Neutral;
            }
        }
    }
}
