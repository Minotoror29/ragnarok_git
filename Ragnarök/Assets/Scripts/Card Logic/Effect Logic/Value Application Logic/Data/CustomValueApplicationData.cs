using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Value Application/Custom")]
public class CustomValueApplicationData : ValueApplicationData
{
    public bool add;

    public override ValueApplication Application(Player player, Effect effect)
    {
        return new CustomValueApplication(player, effect, add);
    }
}
