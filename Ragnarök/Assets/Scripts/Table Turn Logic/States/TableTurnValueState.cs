using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnValueState : TableTurnState
{
    Player _player;
    private CustomValueApplication _valueApplication;
    private bool _add;

    private UnityAction<int> _confirmAction;

    public event Action<Player, int> OnValue;

    public TableTurnValueState(StateManager stateManager, TableTurnManager tableTurnManager, Player player, CustomValueApplication valueApplication, bool add, Action<Player, int> OnValueEvent) : base(stateManager, tableTurnManager)
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
        TableTurnManager.ValueDisplay.Initialize(_add, _confirmAction, _player, _player);
    }

    public override void Exit()
    {
        TableTurnManager.ValueDisplay.gameObject.SetActive(false);
    }

    public void Confirm(int value)
    {
        int actualValue = value;

        if (!_add)
        {
            actualValue = -value;
        }

        OnValue?.Invoke(_player, actualValue);

        _valueApplication.SetValue(actualValue);
    }

    public override void UpdateLogic()
    {
    }
}
