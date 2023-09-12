using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DividePointsEffect : Effect
{
    private ValueApplication _valueApplication;
    private PlayerApplication _playerApplication;

    public DividePointsEffect(Card card, Player sourcePlayer, ValueApplicationData valueApplication, PlayerApplicationData playerApplication) : base(card, sourcePlayer)
    {
        _valueApplication = valueApplication.Application(sourcePlayer, this);
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
            player.DividePoints(_valueApplication.Value);

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

                if (_card.canAvoidRagnarok && _state.TableTurnManager.Clock.Hours == 7)
                {
                    player.TitlePoints[TitlePointsId.Martyr] += 3;
                    Debug.Log(player.PlayerName + " collapsed and earned 3 Martyr points");
                }
            }
        }
    }
}
