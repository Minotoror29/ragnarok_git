using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, ISelectable
{
    private PlayerStateManager _stateManager;
    private TableTurnManager _tableTurnManager;

    [SerializeField] private CinemachineVirtualCamera vCam;

    private List<Player> _opponents;

    private int _roundsWon = 0;
    private int _points;
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private string playerName;

    private bool _mustSkipNextTurn = false;
    private bool _opponentsVoteForCard = false;

    [SerializeField] private Transform targetVotesParent;
    [SerializeField] private Image targetVote;
    private List<Image> _targetVotes;

    [SerializeField] private PlayerOverlay playerOverlay;

    public TableTurnManager TableTurnManager { get { return _tableTurnManager; } }
    public CinemachineVirtualCamera VCam { get { return vCam; } }
    public List<Player> Opponents { get { return _opponents; } }
    public int RoundsWon { get { return _roundsWon; } set { _roundsWon = value; } }
    public int Points { get { return _points; } }
    public TextMeshProUGUI NameText { get { return nameText; } }
    public string PlayerName { get { return playerName; } }
    public bool MustSkipNextTurn { get { return _mustSkipNextTurn; } set { _mustSkipNextTurn = value; } }
    public bool OpponentsVoteForCard { get { return _opponentsVoteForCard; } set { _opponentsVoteForCard = value; } }

    public void Initialize(TableTurnManager tableTurnManager, List<Player> players)
    {
        _stateManager = GetComponent<PlayerStateManager>();
        _tableTurnManager = tableTurnManager;

        nameText.text = playerName;

        _targetVotes = new();

        playerOverlay.Initialize(this);
    }

    public void SetToInactive()
    {
        _stateManager.ChangeState(new PlayerInactiveState(_stateManager, this));
    }

    public void SetOpponents(List<Player> players)
    {
        _opponents = new();
        foreach (Player player in players)
        {
            if (player != this)
            {
                _opponents.Add(player);
            }
        }
    }

    public void ResetContinuousEffects()
    {
        _mustSkipNextTurn = false;
        _opponentsVoteForCard = false;
    }

    public void StartPlayerTurn()
    {
        _stateManager.StartPlayerTurn();
    }

    public void AddPoints(int value)
    {
        _points += value;
        _points = Mathf.Max(_points, 0);

        _stateManager.CheckPoints(_points);

        SetPointsText();
    }

    public void SetPoints(int value)
    {
        _points = value;

        SetPointsText();
    }

    public void DividePoints(float value)
    {
        _points = (int)(_points / value);

        SetPointsText();
    }

    public void SetPointsText()
    {
        pointsText.text = _points.ToString();
        playerOverlay.SetPoints();
    }

    public void EndPlayerTurn()
    {
        _mustSkipNextTurn = false;
        _stateManager.EndPlayerTurn();
    }

    public void WinRound()
    {
        _roundsWon++;
    }

    public void Select(TableTurnState tableTurnState)
    {
        _stateManager.Select(tableTurnState);
    }

    public void RemoveOpponent(Player player)
    {
        if (_opponents.Contains(player))
        {
            _opponents.Remove(player);
        }
    }

    public void TargetVote()
    {
        Image newVote = Instantiate(targetVote, targetVotesParent);
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
}
