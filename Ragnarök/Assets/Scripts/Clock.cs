using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private RoundManager _roundManager;

    [SerializeField] private int maxHours = 8;
    private int _hours;
    [SerializeField] private TextMeshProUGUI hoursText;

    public void Initialize(RoundManager roundManager)
    {
        _roundManager = roundManager;
    }

    public void AddHour(int value)
    {
        _hours += value;
        _hours = Mathf.Clamp(_hours, 0, maxHours);

        SetHoursText();

        if (_hours == maxHours)
        {
            _roundManager.StartRound();
        }
    }

    public void SetHour(int value)
    {
        _hours = value;

        SetHoursText();
    }

    private void SetHoursText()
    {
        hoursText.text = _hours.ToString();
    }
}
