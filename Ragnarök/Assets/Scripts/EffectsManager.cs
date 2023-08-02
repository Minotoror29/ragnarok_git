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
        int stolenValue = 0;

        foreach (Player target in targets)
        {
            stolenValue += Mathf.Clamp(value, 0, target.Points);
            target.AddPoints(-value);
        }

        sourcePlayer.AddPoints(stolenValue);
    }

    public void GivePoints(Player sourcePlayer, List<Player> targets, int value)
    {
        sourcePlayer.AddPoints(-value);

        foreach (Player target in targets)
        {
            target.AddPoints(value);
        }
    }

    public void EqualizePoints(Player sourcePlayer, Player targetPlayer)
    {
        sourcePlayer.SetPoints(targetPlayer.Points);
    }

    public void SkipTurn(List<Player> targets)
    {
        foreach (Player target in targets)
        {
            target.MustSkipNextTurn = true;
        }
    }

    public void OpponentsVoteForCard(Player sourcePlayer)
    {
        sourcePlayer.OpponentsVoteForCard = true;
    }
}
