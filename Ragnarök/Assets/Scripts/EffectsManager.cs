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

    public void SetHour(int value)
    {
        clock.SetHour(value);
    }

    public void AddPointsToPlayers(List<Player> targets, int value)
    {
        foreach (Player target in targets)
        {
            target.AddPoints(value);
        }
    }

    public void DividePlayerPoints(List<Player> targets, float value)
    {
        foreach (Player target in targets)
        {
            target.DividePoints(value);
        }
    }

    public void StealPoints(Player sourcePlayer, List<Player> targets, int value)
    {
        foreach (Player target in targets)
        {
            target.AddPoints(-value);
        }

        sourcePlayer.AddPoints(value * targets.Count);
    }
}
