using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Custom")]
public class CustomValueApplicationData : ValueApplicationData
{
    public bool add;

    public override ValueApplication ValueApplication(Player player, Effect effect, PlayerEffectState state)
    {
        return new CustomValueApplication(player, effect, state, add);
    }
}
