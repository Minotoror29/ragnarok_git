using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerValueState : PlayerState
{
    private EffectsManager _effectsManager;
    private AddCustomHoursEffect _effect;
    private CustomValueApplication _valueApplication;

    private PlayerEffectState _superState;

    private UnityAction<int> _confirmAction;

    public PlayerValueState(EffectsManager effectsManager, Player player, AddCustomHoursEffect effect, CustomValueApplication valueApplication, PlayerEffectState superState) : base(player)
    {
        _effectsManager = effectsManager;
        _effect = effect;
        _valueApplication = valueApplication;
        _superState = superState;
    }

    public override void Enter()
    {
        _player.ValueDisplay.gameObject.SetActive(true);

        _confirmAction += Confirm;
        _player.ValueDisplay.Initialize(_valueApplication.add, _confirmAction, _player);
    }

    public override void Exit()
    {
        _player.ValueDisplay.gameObject.SetActive(false);
    }

    public void Confirm(int value)
    {
        int actualValue = value;

        if (!_valueApplication.add)
        {
            actualValue = -value;
        }

        _effect.Resolve(_effectsManager, _player, actualValue, _superState);
    }

    public override void UpdateLogic()
    {
    }
}
