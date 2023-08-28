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
        int givenValue = Mathf.Clamp(value, 0, sourcePlayer.Points / targets.Count);
        sourcePlayer.AddPoints((-givenValue) * targets.Count);

        foreach (Player target in targets)
        {
            if (target.Wealth == Wealth.Rich)
            {
                sourcePlayer.TitlePoints[TitlePointsId.Assistance]--;
            } else if (target.Wealth == Wealth.Poor)
            {
                sourcePlayer.TitlePoints[TitlePointsId.Assistance]++;
            }

            target.AddPoints(givenValue);
        }
    }

    public void EqualizePoints(Player sourcePlayer, Player targetPlayer)
    {
        if (sourcePlayer.Points < targetPlayer.Points)
        {
            sourcePlayer.TitlePoints[TitlePointsId.Productivism] += 2;
        } else if (sourcePlayer.Points > targetPlayer.Points)
        {
            sourcePlayer.TitlePoints[TitlePointsId.Productivism] -= 2;
        }

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
