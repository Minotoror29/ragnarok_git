using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText;

    public void SetTargetText(string playerName)
    {
        targetText.text = playerName + " is choosing a target";
    }
}
