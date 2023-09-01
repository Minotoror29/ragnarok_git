using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnOpponentsTargetState : TableTurnState
{
    private Player _player;
    private Card _card;
    private TargetPlayersApplication _playerApplication;
    private List<Player> _targetedPlayers;

    private List<Player> _opponents;
    private List<int> _votes;
    private int _playersVoted;

    private UnityAction<Player> _selectAction;
    private UnityAction<Player> _confirmAction;

    public event Action<Player, Player> OnTarget;

    public TableTurnOpponentsTargetState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, Card card, TargetPlayersApplication playerApplication, Action<Player, Player> OnTargetEvent) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _card = card;
        _playerApplication = playerApplication;

        _selectAction += SelectPlayer;
        _confirmAction += Confirm;

        _targetedPlayers = new();
        _opponents = new();
        _votes = new();
        foreach (Player opponent in _player.Opponents)
        {
            _opponents.Add(opponent);
            _votes.Add(0);
        }

        _playersVoted = 0;

        OnTarget = OnTargetEvent;
    }

    public override void Enter()
    {
        for (int i = 0; i < TableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            TableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().EnableSelection(_selectAction);
        }

        TableTurnManager.TargetDisplay.gameObject.SetActive(true);
        TableTurnManager.TargetDisplay.SetTargetText(_opponents[_playersVoted].PlayerName);
    }

    public override void Exit()
    {
        for (int i = 0; i < TableTurnManager.PlayerOverlaysParent.childCount; i++)
        {
            TableTurnManager.PlayerOverlaysParent.GetChild(i).GetComponent<PlayerOverlay>().DisableSelection();
        }

        TableTurnManager.TargetDisplay.gameObject.SetActive(false);
    }

    public override void SelectPlayer(Player selectedPlayer)
    {
        if (selectedPlayer == _player) return;

        _stateManager.ChangeState(new TableTurnTransitionState(_stateManager, TableTurnManager, selectedPlayer.TargetCam,
            new TableTurnConfirmTargetState(_stateManager, TableTurnManager, this, _player, _card.name, selectedPlayer, _confirmAction)));
    }

    private void Confirm(Player targetedPlayer)
    {
        OnTarget?.Invoke(_opponents[_playersVoted], targetedPlayer);
        _votes[_opponents.IndexOf(targetedPlayer)]++;
        targetedPlayer.TargetVote();
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

            _targetedPlayers.Add(opponentsWithHighestVotes[UnityEngine.Random.Range(0, opponentsWithHighestVotes.Count)]);
            foreach (Player opponent in _opponents)
            {
                opponent.ClearTargetVotes();
            }
            _playerApplication.SetTargets(_targetedPlayers);
        } else
        {
            _stateManager.ChangeState(this);
        }
    }

    public override void UpdateLogic()
    {
    }
}
