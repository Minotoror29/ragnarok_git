using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStartState : RoundState
{
    private float _startTime = 5f;
    private float _startTimer;

    public RoundStartState(StateManager stateManager, RoundManager roundManager, int roundNumber) : base(stateManager, roundManager, roundNumber)
    {
    }

    public override void Enter()
    {
        _roundManager.TopCam.gameObject.SetActive(true);
        _roundManager.StartRoundDisplay.gameObject.SetActive(true);
        _roundManager.StartRoundDisplay.SetRoundText(_roundNumber);

        _roundManager.Clock.SetHour(0);
        _roundManager.Deck.PutCardsBack();

        _roundManager.TableTurnManager.RagnarokResponsiblePlayers.Clear();

        foreach (Player player in _roundManager.ActivePlayers)
        {
            player.CreateOverlay(_roundManager.PlayerOverlaysParent);
            player.SetToInactive();
            player.SetOpponents(_roundManager.ActivePlayers);
            player.SetPoints(_roundManager.PlayersStartPoints);
            player.ResetContinuousEffects();
        }

        _startTimer = _startTime;
    }

    public override void Exit()
    {
        _roundManager.TopCam.gameObject.SetActive(false);
        _roundManager.StartRoundDisplay.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
        if (_startTimer > 0)
        {
            _startTimer -= Time.deltaTime;
        } else
        {
            _stateManager.ChangeState(new RoundTableTurnState(_stateManager, _roundManager, _roundNumber, 0));
        }
    }
}
