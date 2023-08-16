using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerOverlay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerPoints;
    [SerializeField] private Button flag;

    private Player _player;

    private UnityAction<Player> _selectAction;

    public Button Flag { get { return flag; } }

    public void Initialize(Player player)
    {
        _player = player;
        playerName.text = player.PlayerName;

        SetPoints();
    }

    public void EnableSelection(UnityAction<Player> action)
    {
        _selectAction = action;
    }

    public void DisableSelection()
    {
        _selectAction = null;
    }

    public void Select()
    {
        if (_selectAction == null) return;

        _selectAction.Invoke(_player);
    }

    public void SetPoints()
    {
        playerPoints.text = _player.Points.ToString();
    }
}
