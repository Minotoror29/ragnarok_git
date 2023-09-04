using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnOpponentsValueState : TableTurnState
{
    Player _player;
    private CustomValueApplication _valueApplication;
    private bool _add;

    private UnityAction<int> _confirmAction;

    private int _playersVoted;
    private List<int> _chosenValues;

    public event Action<Player, int> OnValue;

    public TableTurnOpponentsValueState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, CustomValueApplication valueApplication , bool add, Action<Player, int> OnValueEvent) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _valueApplication = valueApplication;
        _add = add;
        OnValue = OnValueEvent;
    }

    public override void Enter()
    {
        TableTurnManager.ValueDisplay.gameObject.SetActive(true);

        _confirmAction += Confirm;
        TableTurnManager.ValueDisplay.Initialize(_add, _confirmAction, _player, _player.Opponents[_playersVoted]);

        _playersVoted = 0;
        _chosenValues = new();
    }

    public override void Exit()
    {
        TableTurnManager.ValueDisplay.gameObject.SetActive(false);
    }

    public void Confirm(int value)
    {
        if (_add)
        {
            OnValue?.Invoke(_player.Opponents[_playersVoted], value);
        } else
        {
            OnValue?.Invoke(_player.Opponents[_playersVoted], -value);
        }
        _chosenValues.Add(value);
        _playersVoted++;

        if (_playersVoted == _player.Opponents.Count)
        {
            int addedValue = 0;

            foreach (int v in _chosenValues)
            {
                addedValue += v;
            }

            int actualValue = addedValue / _player.Opponents.Count;

            if (!_add)
            {
                actualValue *= -1;
            }

            _valueApplication.SetValue(actualValue);
        } else
        {
            TableTurnManager.ValueDisplay.Initialize(_add, _confirmAction, _player, _player.Opponents[_playersVoted]);
        }
    }

    public override void UpdateLogic()
    {
    }
}
