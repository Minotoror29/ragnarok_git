using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private RoundManager _roundManager;

    [SerializeField] private int maxHours = 8;
    private int _hours;
    [SerializeField] private List<TextMeshProUGUI> hoursTexts;

    private bool _hasHourChanged = false;

    public int Hours { get { return _hours; } }
    public bool HasHourChanged { get { return _hasHourChanged; } }

    public void Initialize(RoundManager roundManager)
    {
        _roundManager = roundManager;
    }

    public void AddHours(int value)
    {
        _hours += value;
        _hours = Mathf.Clamp(_hours, 0, maxHours);

        _hasHourChanged = true;
    }

    public void SetHour(int value)
    {
        if (_hours != value)
        {
            _hasHourChanged = true;
        }

        _hours = value;
    }

    public void SetHoursText()
    {
        foreach (TextMeshProUGUI hoursText in hoursTexts)
        {
            hoursText.text = _hours.ToString();
        }

        _hasHourChanged = false;
    }

    public bool IsAtMidnight()
    {
        return _hours == maxHours;
    }
}
