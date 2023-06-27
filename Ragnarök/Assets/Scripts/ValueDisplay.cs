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
    [SerializeField] private Button confirmButton;
    private int _value;
    private int _minValue = 0;
    private int _maxValue = 8;

    UnityAction<int> _confirmAction;

    public void Initialize(bool add, UnityAction<int> action)
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

    private void AddConfirm(UnityAction<int> action)
    {
        //confirmButton.onClick.AddListener(action);
    }

    public void RemoveConfirm()
    {
        confirmButton.onClick.RemoveAllListeners();
    }

    public void Confirm()
    {
        _confirmAction.Invoke(_value);
    }
}
