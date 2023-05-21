using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private MatchManager _matchManager;

    [SerializeField] private int maxHours = 8;
    private int _hours;
    [SerializeField] private TextMeshProUGUI hoursText;

    public void Initialize(MatchManager matchManager)
    {
        _matchManager = matchManager;
    }

    public void AddHours(int value)
    {
        _hours += value;
        _hours = Mathf.Clamp(_hours, 0, maxHours);

        SetHoursText();

        if (_hours == maxHours)
        {
            _matchManager.StartNewRound();
        }
    }

    public void SetHours(int value)
    {
        _hours = value;

        SetHoursText();
    }

    private void SetHoursText()
    {
        hoursText.text = _hours.ToString();
    }
}
