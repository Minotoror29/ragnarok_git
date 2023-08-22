using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, ISelectable
{
    private PlayerStateManager _stateManager;

    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private CinemachineVirtualCamera targetCam;

    private List<Player> _opponents;

    private int _roundsWon = 0;
    private int _points;
    [SerializeField] private TextMeshProUGUI pointsText;

    [SerializeField] private TextMeshProUGUI nameText;
    private string _playerName;

    private bool _mustSkipNextTurn = false;
    private bool _opponentsVoteForCard = false;

    [SerializeField] private PlayerOverlay playerOverlayPrefab;
    private PlayerOverlay _playerOverlay;

    //public TitlePoints _titlePoints;
    private Dictionary<TitlePointsId, int> _titlePoints;

    public CinemachineVirtualCamera VCam { get { return vCam; } }
    public CinemachineVirtualCamera TargetCam { get { return targetCam; } }
    public List<Player> Opponents { get { return _opponents; } }
    public int RoundsWon { get { return _roundsWon; } set { _roundsWon = value; } }
    public int Points { get { return _points; } }
    public TextMeshProUGUI NameText { get { return nameText; } }
    public string PlayerName { get { return _playerName; } }
    public bool MustSkipNextTurn { get { return _mustSkipNextTurn; } set { _mustSkipNextTurn = value; } }
    public bool OpponentsVoteForCard { get { return _opponentsVoteForCard; } set { _opponentsVoteForCard = value; } }
    //public TitlePoints TitlePoints { get { return _titlePoints; } set { _titlePoints = value; } }
    public Dictionary<TitlePointsId, int> TitlePoints { get { return _titlePoints; } }

    public void Initialize(string playerName, Transform playerOverlaysParent)
    {
        _stateManager = GetComponent<PlayerStateManager>();

        _playerName = playerName;
        nameText.text = playerName;

        PlayerOverlay newOverlay = Instantiate(playerOverlayPrefab, playerOverlaysParent);
        _playerOverlay = newOverlay;
        _playerOverlay.Initialize(this);
        Canvas.ForceUpdateCanvases();
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

    public void ResetTitlePoints()
    {
        _titlePoints = new Dictionary<TitlePointsId, int>
        {
            {TitlePointsId.TotalPower, 0 },
            {TitlePointsId.Productivism, 0 },
            {TitlePointsId.Imperialism, 0 },
            {TitlePointsId.Extinction, 0 },
            {TitlePointsId.Ragnarok, 0 },
            {TitlePointsId.Martyr, 0 },
            {TitlePointsId.Assistance, 0 }
        };
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
        _playerOverlay.SetPoints();
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
        _playerOverlay.TargetVote();
    }

    public void ClearTargetVotes()
    {
        _playerOverlay.ClearTargetVotes();
    }
}
