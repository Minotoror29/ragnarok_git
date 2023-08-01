using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableTurnOpponentsValueState : TableTurnState
{
    Player _player;
    private CustomValueApplication _valueApplication;
    private TableTurnEffectState _effectState;
    private bool _add;

    private UnityAction<int> _confirmAction;

    private int _opponentsChose;
    private List<int> _chosenValues;

    public TableTurnOpponentsValueState(TableTurnManager tableTurnManager, Player player, CustomValueApplication valueApplication, TableTurnEffectState effectState, bool add, StateManager stateManager = null) : base(stateManager, tableTurnManager)
    {
        _player = player;
        _valueApplication = valueApplication;
        _effectState = effectState;
        _add = add;
    }

    public override void Enter()
    {
        _tableTurnManager.ValueDisplay.gameObject.SetActive(true);

        _confirmAction += Confirm;
        _tableTurnManager.ValueDisplay.Initialize(_add, _confirmAction, _player);

        _opponentsChose = 0;
        _chosenValues = new();
    }

    public override void Exit()
    {
        _tableTurnManager.ValueDisplay.gameObject.SetActive(false);
    }

    public void Confirm(int value)
    {
        _chosenValues.Add(value);
        _opponentsChose++;
        _tableTurnManager.ValueDisplay.Initialize(_add, _confirmAction, _player);

        if (_opponentsChose == _player.Opponents.Count)
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
            _effectState.ExitSubState();
        }
    }

    public override void UpdateLogic()
    {
    }
}
