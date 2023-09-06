using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StealEffect : Effect
{
    public PlayerApplication _playerApplication;
    public ValueApplication _valueApplication;

    public StealEffect(Player sourcePlayer, TableTurnEffectState state, PlayerApplicationData playerApplication, ValueApplicationData valueApplication) : base(sourcePlayer, state)
    {
        _playerApplication = playerApplication.Application(sourcePlayer, this, state);
        _valueApplication = valueApplication.Application(sourcePlayer, this, state);
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
        int stolenValue = 0;

        foreach (Player target in _playerApplication.Targets)
        {
            stolenValue += Mathf.Clamp(_valueApplication.Value, 0, target.Points);
            target.AddPoints(-_valueApplication.Value);

            if (target.Points == 0)
            {
                foreach (Player responsiblePlayer in _playerApplication.ResponsiblePlayers)
                {
                    if (responsiblePlayer != target)
                    {
                        responsiblePlayer.TitlePoints[TitlePointsId.Extinction]++;
                        Debug.Log(responsiblePlayer.PlayerName + " was responsible for " + target.PlayerName + "'s collapse and earned 1 Extinction point");
                    }
                }
            }
        }

        _player.AddPoints(stolenValue);
    }
}
