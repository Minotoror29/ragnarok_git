using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class TargetWealthRelativeTitlePointsApplication : TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private int _poorValue;
    private int _neutralValue;
    private int _richValue;

    private List<Player> _targets;

    public TargetWealthRelativeTitlePointsApplication(TableTurnCardState cardState,
        TitlePointsId titlePointsId, int poorValue, int neutralValue, int richValue) : base(cardState)
    {
        _titlePointsId = titlePointsId;
        _poorValue = poorValue;
        _neutralValue = neutralValue;
        _richValue = richValue;

        _targets = new();

        cardState.OnTarget += AddPlayerAndTarget;
    }

    private void AddPlayerAndTarget(Player player, Player target)
    {
        AddPlayer(player);
        AddTarget(target);
    }

    private void AddTarget(Player target)
    {
        _targets.Add(target);
    }

    public override void AssignPoints()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            switch(_targets[i].Wealth)
            {
                case Wealth.Poor:
                    Players[i].TitlePoints[_titlePointsId] += _poorValue;
                    Debug.Log(Players[i].PlayerName + " earned " + _poorValue + " " + _titlePointsId.ToString() + " points");
                    break;
                case Wealth.Neutral:
                    Players[i].TitlePoints[_titlePointsId] += _neutralValue;
                    Debug.Log(Players[i].PlayerName + " earned " + _neutralValue + " " + _titlePointsId.ToString() + " points");
                    break;
                case Wealth.Rich:
                    Players[i].TitlePoints[_titlePointsId] += _richValue;
                    Debug.Log(Players[i].PlayerName + " earned " + _richValue + " " + _titlePointsId.ToString() + " points");
                    break;
            }
        }
    }
}
