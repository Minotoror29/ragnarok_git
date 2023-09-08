using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI valueDisplay;
    private int _value;
    private int _minValue = 1;
    private int _maxValue = 8;

    UnityAction<int> _confirmAction;

    [SerializeField] private Clock clock;

    public void Initialize(bool add, UnityAction<int> action, Player player, Player chosingPlayer)
    {
        if (add)
        {
            title.text = chosingPlayer.PlayerName + " fait avancer l'horloge de :";
            _maxValue = 8 - clock.Hours;
        } else
        {
            title.text = chosingPlayer.PlayerName + " fait reculer l'horloge de :";
            _maxValue = player.Points;
            _maxValue = Mathf.Clamp(_maxValue, 0, clock.Hours);
        }

        _value = _minValue;
        UpdateValueDisplay();

        _confirmAction = action;
    }

    public void UdpateValue(int value)
    {
        _value += value;
        _value = Mathf.Clamp(_value, _minValue, _maxValue);
        UpdateValueDisplay();
    }

    private void UpdateValueDisplay()
    {
        valueDisplay.text = _value.ToString();
    }

    public void Confirm()
    {
        _confirmAction.Invoke(_value);
    }
}
