using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointsRelativeTitlePointsApplication : TitlePointsApplication
{
    private TitlePointsId _titlePointsId;
    private int _superiorValue;
    private int _equalValue;
    private int _inferiorValue;

    private int _playerPoints;
    private List<int> _points;

    public TargetPointsRelativeTitlePointsApplication(TableTurnCardState cardState, TitlePointsId titlePointsId, int superiorValue, int equalValue, int inferiorValue) : base(cardState)
    {
        _titlePointsId = titlePointsId;
        _superiorValue = superiorValue;
        _equalValue = equalValue;
        _inferiorValue = inferiorValue;

        _playerPoints = CardState.Player.Points;
        _points = new();

        cardState.OnTarget += AddPlayerAndTargetPoints;
    }

    private void AddPlayerAndTargetPoints(Player player, Player target)
    {
        AddPlayer(player);
        _points.Add(target.Points);
    }

    public override void AssignPoints()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            if (_points[i] > _playerPoints)
            {
                Players[i].TitlePoints[_titlePointsId] += _superiorValue;
                Debug.Log(Players[i].PlayerName + " earned " + _superiorValue + " " + _titlePointsId.ToString() + " points");
            } else if (_points[i] == _playerPoints)
            {
                Players[i].TitlePoints[_titlePointsId] += _equalValue;
                Debug.Log(Players[i].PlayerName + " earned " + _equalValue + " " + _titlePointsId.ToString() + " points");
            } else if (_points[i] < _playerPoints)
            {
                Players[i].TitlePoints[_titlePointsId] += _inferiorValue;
                Debug.Log(Players[i].PlayerName + " earned " + _inferiorValue + " " + _titlePointsId.ToString() + " points");
            }
        }
    }
}
