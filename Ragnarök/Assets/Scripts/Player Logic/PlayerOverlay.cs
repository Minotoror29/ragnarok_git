using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerPoints;

    private Player _player;

    public void Initialize(Player player)
    {
        _player = player;
        playerName.text = player.PlayerName;

        SetPoints();
    }

    public void SetPoints()
    {
        playerPoints.text = _player.Points.ToString();
    }
}
