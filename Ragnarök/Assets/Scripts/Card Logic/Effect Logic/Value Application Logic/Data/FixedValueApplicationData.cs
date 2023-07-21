using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Fixed")]
public class FixedValueApplicationData : ValueApplicationData
{
    public int value;

    public override ValueApplication Application(Player player, Effect effect, TableTurnEffectState state)
    {
        return new FixedValueApplication(player, effect, state, value);
    }
}
