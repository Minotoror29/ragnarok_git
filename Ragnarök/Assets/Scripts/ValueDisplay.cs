using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ValueDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI valueDisplay;
    private int _value;
    private int _minValue = 0;
    private int _maxValue = 8;

    public void Initialize(bool add)
    {
        if (add)
        {
            title.text = "L'horloge avance de :";
        } else
        {
            title.text = "L'horloge recule de :";
        }

        _value = 0;
        UpdateValueDisplay();
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

    }
}
