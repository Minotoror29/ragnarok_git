using System.Collections.Generic;

public abstract class Effect
{
    protected Player _player;
    protected TableTurnEffectState _state;

    protected int _resolvedApplications;

    protected ValueApplication _previousValueApplication;

    public Effect(Player sourcePlayer, TableTurnEffectState state)
    {
        _player = sourcePlayer;
        _state = state;

        _resolvedApplications = 0;
    }

    public abstract void Activate();
    public virtual void NextApplication()
    {
        _resolvedApplications++;
    }
    public abstract void Resolve(EffectsManager effectsManager);
}
