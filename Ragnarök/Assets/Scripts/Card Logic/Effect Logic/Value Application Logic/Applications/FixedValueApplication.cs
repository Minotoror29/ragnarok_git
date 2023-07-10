using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedValueApplication : ValueApplication
{
    public FixedValueApplication(Player player, Effect effect, PlayerEffectState state, int value) : base(player, effect, state)
    {
        _value = value;
    }

    public override void DetermineValue()
    {
        _effect.NextApplication();
    }
}
