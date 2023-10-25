using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerOverlay : MonoBehaviour
{
    private Player _player;

    [SerializeField] private TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI playerPoints;

    [SerializeField] private Transform targetVotesParent;
    [SerializeField] private Image targetVotePrefab;
    private List<Image> _targetVotes;

    [SerializeField] private Image crownPrefab;
    [SerializeField] private Transform crownsParent;
    private List<Image> _crowns;

    private event Action<Player> SelectAction;

    public void Initialize(Player player, int roundsWon)
    {
        _player = player;
        playerName.text = player.PlayerName;

        SetPoints();

        _targetVotes = new();
        _crowns = new();

        for (int i = 0; i < roundsWon; i++)
        {
            AddCrown();
        }
    }

    public void EnableSelection(Action<Player> action)
    {
        SelectAction = action;
    }

    public void DisableSelection()
    {
        SelectAction = null;
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
            Destroy(vote.gameObject);
        }

        _targetVotes.Clear();
    }

    public void SetColor(Color color)
    {
        playerName.color = color;
    }

    public void AddCrown()
    {
        Image newCrown = Instantiate(crownPrefab, crownsParent);
        _crowns.Add(newCrown);
    }
}
