using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomValueApplication : ValueApplication
{
    private bool _add;

    public CustomValueApplication(Player player, Effect effect, bool add) : base(player, effect)
    {
        _add = add;
    }

    public override void DetermineValue()
    {
        _state.EnterValueSubState(this, _add);
    }

    public void SetValue(int value)
    {
        _value = value;
        _effect.NextApplication();
    }
}
