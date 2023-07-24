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
            _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber));
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
            _roundManager.ActivePlayers.Count == 1 ||
            _roundManager.ActivePlayers.Count == 0)
        {
            _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber));
            return true;
        } else
        {
            return false;
        }
    }

    //public void EndRound()
    //{
    //    _stateManager.ChangeState(new RoundEndState(_stateManager, _roundManager, _roundNumber));
    //}

}
