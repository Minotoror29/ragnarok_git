using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctrineEffect : Effect
{
    private CustomValueApplication _valueApplication;
    private YouApplication _playerApplication;

    public DoctrineEffect(CardData card, Player sourcePlayer, bool add) : base(card, sourcePlayer)
    {
        _valueApplication = new CustomValueApplication(sourcePlayer, this, add);
        _playerApplication = new YouApplication(sourcePlayer, this);
    }

    public override void SetEffectState(TableTurnEffectState state)
    {
        base.SetEffectState(state);

        _valueApplication.SetEffectState(state);
        _playerApplication.SetEffectState(state);
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

                if (_card.canAvoidRagnarok && _state.TableTurnManager.Clock.Hours == 7)
                {
                    player.TitlePoints[TitlePointsId.Martyr] += 3;
                    Debug.Log(player.PlayerName + " collapsed and earned 3 Martyr points");
                }
            }
        }

        _state.TableTurnManager.Clock.AddHours(_valueApplication.Value);
    }
}
