using System.Collections.Generic;

public abstract class Effect
{
    protected CardData _card;
    protected Player _player;
    protected TableTurnEffectState _state;

    protected int _resolvedApplications;

    protected ValueApplication _previousValueApplication;

    public TableTurnEffectState State { get { return _state; } }

    public Effect(CardData card, Player sourcePlayer)
    {
        _card = card;
        _player = sourcePlayer;

        _resolvedApplications = 0;
    }

    public virtual void SetEffectState(TableTurnEffectState state)
    {
        _state = state;
    }

    public virtual void CheckGameState(TableTurnCardState state)
    {

    }

    public abstract void Activate();
    public virtual void NextApplication()
    {
        _resolvedApplications++;
    }
    public abstract void Resolve();
}
