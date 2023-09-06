using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GiveEffect : Effect
{
    private ValueApplication _valueApplication;
    private PlayerApplication _playerApplication;

    public GiveEffect(Player sourcePlayer, TableTurnEffectState state, ValueApplicationData valueApplication, PlayerApplicationData playerApplication) : base(sourcePlayer, state)
    {
        _valueApplication = valueApplication.Application(sourcePlayer, this, state);
        _playerApplication = playerApplication.Application(sourcePlayer, this, state);
    }

    public override void Activate()
    {
        _playerApplication.DetermineTargets();
    }

    public override void NextApplication()
    {
        base.NextApplication();

        if (_resolvedApplications == 1)
        {
            _valueApplication.DetermineValue();
        }
        else if (_resolvedApplications == 2)
        {
            _state.NextEffect();
        }
    }

    public override void Resolve()
    {
        int givenValue = Mathf.Clamp(_valueApplication.Value, 0, _player.Points / _playerApplication.Targets.Count);
        _player.AddPoints((-givenValue) * _playerApplication.Targets.Count);

        foreach (Player target in _playerApplication.Targets)
        {
            target.AddPoints(givenValue);
        }

        if (_player.Points == 0)
        {
            foreach (Player responsiblePlayer in _playerApplication.ResponsiblePlayers)
            {
                if (responsiblePlayer != _player)
                {
                    responsiblePlayer.TitlePoints[TitlePointsId.Extinction]++;
                    Debug.Log(responsiblePlayer.PlayerName + " was responsible for " + _player.PlayerName + "'s collapse and earned 1 Extinction point");
                }
            }
        }
    }
}
