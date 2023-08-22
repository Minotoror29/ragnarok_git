using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerTitleDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI titleText;

    public void Initialize(string playerName, string title)
    {
        playerNameText.text = playerName;
        titleText.text = title;
    }
}
