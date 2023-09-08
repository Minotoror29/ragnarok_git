using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPointsEffect : Effect
{
    private ValueApplication _valueApplication;
    private PlayerApplication _playerApplication;

    public AddPointsEffect(Card card, Player sourcePlayer, ValueApplicationData valueApplicationData, PlayerApplicationData playerApplication) : base(card, sourcePlayer)
    {
        _valueApplication = valueApplicationData.Application(sourcePlayer, this);
        _playerApplication = playerApplication.Application(sourcePlayer, this);
    }

    public override void SetEffectState(TableTurnEffectState state)
    {
        base.SetEffectState(state);

        _valueApplication.SetEffectState(state);
        _playerApplication.SetEffectState(state);
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
        foreach (Player player in _playerApplication.Targets)
        {
            player.AddPoints(_valueApplication.Value);

            if (player.Points == 0)
            {
                foreach (Player responsiblePlayer in _playerApplication.ResponsiblePlayers)
                {
                    if (responsiblePlayer != player)
                    {
                        responsiblePlayer.TitlePoints[TitlePointsId.Extinction]++;
                        Debug.Log(responsiblePlayer.PlayerName + " was responsible for " + player.PlayerName + "'s collapse and earned 1 Extinction point");
                    }
                }
            }
        }
    }
}
