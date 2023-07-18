using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefaultState : PlayerState
{
    private MatchManager _matchManager;

    public PlayerDefaultState(StateManager stateManager, MatchManager matchManager, Player player) : base(stateManager, player)
    {
        _matchManager = matchManager;
    }

    public override void Enter()
    {
        _player.SelectionManager.Enable(this);
    }

    public override void Exit()
    {
        _player.SelectionManager.Disable();
    }

    public override void SelectDeck(Card card)
    {
        _stateManager.ChangeState(new PlayerCardState(_stateManager, _matchManager, _player, card));
    }

    public override void UpdateLogic()
    {
        _player.SelectionManager.UpdateLogic();
    }
}
