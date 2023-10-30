using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SetHourEffect : Effect
{
    private ValueApplication _valueApplication;

    public SetHourEffect(CardData card, Player sourcePlayer, ValueApplicationData valueApplicationData) : base(card, sourcePlayer)
    {
        _valueApplication = valueApplicationData.Application(sourcePlayer, this);
    }

    public override void CheckGameState(TableTurnCardState state)
    {
        base.CheckGameState(state);

        if (state.TableTurnManager.Clock.Hours > _valueApplication.Value)
        {
            state.CanAvoidRagnarok = true;
        } else if (state.TableTurnManager.Clock.Hours < _valueApplication.Value)
        {
            state.CanTriggerRagnarok = true;
        }
    }

    public override void SetEffectState(TableTurnEffectState state)
    {
        base.SetEffectState(state);

        _valueApplication.SetEffectState(state);
    }

    public override void Activate()
    {
        _valueApplication.DetermineValue();
    }

    public override void NextApplication()
    {
        base.NextApplication();

        _state.NextEffect();
    }

    public override void Resolve()
    {
        _state.TableTurnManager.Clock.SetHour(_valueApplication.Value);
    }
}
