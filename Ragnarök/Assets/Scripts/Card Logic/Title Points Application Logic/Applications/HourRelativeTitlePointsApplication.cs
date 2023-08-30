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

    public HourRelativeTitlePointsApplication(TitlePointsId titlePointsId, int minValue, int maxValue, int hoursToGetMaxValue, Clock clock)
    {
        _titlePointsId = titlePointsId;
        _minValue = minValue;
        _maxValue = maxValue;
        _hoursToGetMaxValue = hoursToGetMaxValue;

        _clock = clock;
        _startHours = _clock.Hours;
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
    }
}
