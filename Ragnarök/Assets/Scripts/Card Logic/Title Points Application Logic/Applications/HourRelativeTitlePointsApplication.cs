using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class HourRelativeTitlePointsApplication : TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private int _minValue;
    private int _maxValue;
    private int _hoursToGetMaxValue;

    private Clock _clock;
    private int _startHours;

    public HourRelativeTitlePointsApplication(TableTurnCardState cardState, TitlePointsId titlePointsId, int minValue, int maxValue, int hoursToGetMaxValue) : base(cardState)
    {
        _titlePointsId = titlePointsId;
        _minValue = minValue;
        _maxValue = maxValue;
        _hoursToGetMaxValue = hoursToGetMaxValue;

        _clock = cardState.TableTurnManager.Clock;
        _startHours = _clock.Hours;

        cardState.OnVote += AddPlayer;
    }

    public override void AssignPoints()
    {
        foreach (Player player in Players)
        {
            if (_clock.Hours < _startHours + _hoursToGetMaxValue)
            {
                player.TitlePoints[_titlePointsId] += _minValue;
                Debug.Log(player.PlayerName + " earned " + _minValue + " " + _titlePointsId.ToString() + " points");
            } else if (_clock.Hours > _startHours + _hoursToGetMaxValue)
            {
                Debug.Log(player.PlayerName + " earned " + _maxValue + " " + _titlePointsId.ToString() + " points");
            }
        }

        CardState.OnVote -= AddPlayer;
    }
}
