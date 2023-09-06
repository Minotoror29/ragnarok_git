using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctrineEffect : Effect
{
    private CustomValueApplication _valueApplication;
    private YouApplication _playerApplication;

    public DoctrineEffect(Player sourcePlayer, TableTurnEffectState state, bool add) : base(sourcePlayer, state)
    {
        _valueApplication = new CustomValueApplication(sourcePlayer, this, state, add);
        _playerApplication = new YouApplication(sourcePlayer, this);
    }

    public override void Activate()
    {
        _valueApplication.DetermineValue();
    }

    public override void NextApplication()
    {
        base.NextApplication();

        if (_resolvedApplications == 1)
        {
            _playerApplication.DetermineTargets();
        } else
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

        _state.TableTurnManager.Clock.AddHours(_valueApplication.Value);
    }
}
