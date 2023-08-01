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

    public int Hours { get { return _hours; } }

    public void Initialize(RoundManager roundManager)
    {
        _roundManager = roundManager;
    }

    public void AddHours(int value)
    {
        _hours += value;
        _hours = Mathf.Clamp(_hours, 0, maxHours);

        SetHoursText();
    }

    public void SetHour(int value)
    {
        _hours = value;

        SetHoursText();
    }

    private void SetHoursText()
    {
        foreach (TextMeshProUGUI hoursText in hoursTexts)
        {
            hoursText.text = _hours.ToString();
        }
    }

    public bool IsAtMidnight()
    {
        return _hours == maxHours;
    }
}
