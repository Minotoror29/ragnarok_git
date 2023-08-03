using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayerSelectionState : GameState
{
    private List<string> _playerNames;

    public GamePlayerSelectionState(StateManager stateManager, GameManager gameManager) : base(stateManager, gameManager)
    {
    }

    public override void Enter()
    {
        PlayerSelectionManager.Instance.Initialize(this);
    }

    public override void Exit()
    {
    }

    public override void UpdateLogic()
    {
    }

    public override void OnSceneChanged(Scene currentScene, Scene nextScene)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _stateManager.ChangeState(new GameMatchState(_stateManager, _gameManager, _playerNames));
        }
    }

    public void SetPlayerNames(List<string> playerNames)
    {
        _playerNames = new();

        foreach (string playerName in playerNames)
        {
            _playerNames.Add(playerName);
        }
    }
}
