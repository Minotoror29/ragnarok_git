using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomValueApplication : ValueApplication
{
    private bool _add;

    public CustomValueApplication(Player player, Effect effect, PlayerEffectState state, bool add) : base(player, effect, state)
    {
        _add = add;
    }

    public override void DetermineValue()
    {
        _state.EnterSubState(new PlayerValueState(_player, this, _add));
    }

    public void SetValue(int value)
    {
        _value = value;
        _effect.NextApplication();
    }
}
