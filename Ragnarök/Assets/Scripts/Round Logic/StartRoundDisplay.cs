using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartRoundDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundText;

    public void SetRoundText(int roundNumber)
    {
        roundText.text = "ROUND " + roundNumber;
    }
}
