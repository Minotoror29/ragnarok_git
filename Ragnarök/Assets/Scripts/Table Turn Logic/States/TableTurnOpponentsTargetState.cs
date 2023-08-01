using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTurnOpponentsTargetState : TableTurnState
{
    private Player _player;
    private TargetPlayersApplication _playerApplication;
    private TableTurnEffectState _effectState;
    private List<Player> _targetedPlayers;

    private List<Player> _opponents;
    private List<int> _votes;
    private int _playersVoted;

    public TableTurnOpponentsTargetState(TableTurnManager tableTurnManager, Player player, TargetPlayersApplication playerApplication, TableTurnEffectState effectState, StateManager stateManager = null) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _playerApplication = playerApplication;
        _effectState = effectState;
    }

    public override void Enter()
    {
        _tableTurnManager.SelectionManager.Enable(this);
        _targetedPlayers = new();

        _opponents = new();
        _votes = new();
        foreach (Player opponent in _player.Opponents)
        {
            _opponents.Add(opponent);
            _votes.Add(0);
        }

        _playersVoted = 0;
    }

    public override void Exit()
    {
        _tableTurnManager.SelectionManager.Disable();
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
        if (selectedPlayer == _player) return;

        _votes[_opponents.IndexOf(selectedPlayer)]++;
        selectedPlayer.TargetVote();
        _playersVoted++;

        if (_playersVoted == _opponents.Count)
        {
            int highestVotes = 0;

            foreach (int votes in _votes)
            {
                if (votes > highestVotes)
                {
                    highestVotes = votes;
                }
            }

            List<Player> opponentsWithHighestVotes = new();
            for (int i = 0; i < _votes.Count; i++)
            {
                if (_votes[i] == highestVotes)
                {
                    opponentsWithHighestVotes.Add(_opponents[i]);
                }
            }

            _targetedPlayers.Add(opponentsWithHighestVotes[Random.Range(0, opponentsWithHighestVotes.Count)]);
            foreach (Player opponent in _opponents)
            {
                opponent.ClearTargetVotes();
            }
            _playerApplication.SetTargets(_targetedPlayers);
            _effectState.ExitSubState();
        }
    }

    public override void UpdateLogic()
    {
        _tableTurnManager.SelectionManager.UpdateLogic();
    }
}
