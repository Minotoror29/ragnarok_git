using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedValueApplication : ValueApplication
{
    public FixedValueApplication(Player player, Effect effect, int value) : base(player, effect)
    {
        _value = value;
    }

    public override void DetermineValue()
    {
        _effect.NextApplication();
    }
}
