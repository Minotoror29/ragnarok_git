using System;
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

    [SerializeField] private Transform targetVotesParent;
    [SerializeField] private Image targetVotePrefab;
    private List<Image> _targetVotes;

    private Player _player;

    private bool _actionEnabled = false;
    private event Action<Player> SelectAction;

    public void Initialize(Player player)
    {
        _player = player;
        playerName.text = player.PlayerName;

        SetPoints();

        _targetVotes = new();
    }

    public void EnableSelection(Action<Player> action)
    {
        SelectAction = action;
        _actionEnabled = true;
    }

    public void DisableSelection()
    {
        SelectAction = null;
        _actionEnabled = false;
    }

    public void Select()
    {
        if (SelectAction == null) return;

        SelectAction.Invoke(_player);
    }

    public void SetPoints()
    {
        playerPoints.text = _player.Points.ToString();
    }

    public void TargetVote()
    {
        Image newVote = Instantiate(targetVotePrefab, targetVotesParent);
        _targetVotes.Add(newVote);
    }

    public void ClearTargetVotes()
    {
        foreach (Image vote in _targetVotes)
        {
            Destroy(vote);
        }

        _targetVotes.Clear();
    }

    public void SetColor(Color color)
    {
        playerName.color = color;
    }
}
