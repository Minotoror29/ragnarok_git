using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    [SerializeField] private Clock clock;

    public void AddHours(int value)
    {
        clock.AddHours(value);
    }

    public void AddPointsToPlayer(Player player, int value)
    {
        player.AddPoints(value);
    }
}
