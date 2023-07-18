using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerValueState : PlayerState
{
    private CustomValueApplication _valueApplication;

    private bool _add;

    private UnityAction<int> _confirmAction;

    public PlayerValueState(Player player, CustomValueApplication valueApplication, bool add, StateManager stateManager = null) : base(stateManager, player)
    {
        _valueApplication = valueApplication;

        _add = add;
    }

    public override void Enter()
    {
        _player.ValueDisplay.gameObject.SetActive(true);

        _confirmAction += Confirm;
        _player.ValueDisplay.Initialize(_add, _confirmAction, _player);
    }

    public override void Exit()
    {
        _player.ValueDisplay.gameObject.SetActive(false);
    }

    public void Confirm(int value)
    {
        int actualValue = value;

        if (!_add)
        {
            actualValue = -value;
        }

        _valueApplication.SetValue(actualValue);
    }

    public override void UpdateLogic()
    {
    }
}
