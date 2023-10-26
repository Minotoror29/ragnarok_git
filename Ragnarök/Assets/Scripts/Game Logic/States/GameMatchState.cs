using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMatchState : GameState
{
    private List<string> _playerNames;
    private MatchManager _matchManager;

    public GameMatchState(StateManager stateManager, GameManager gameManager, List<string> playerNames) : base(stateManager, gameManager)
    {
        _playerNames = new();
        foreach (string name in playerNames)
        {
            _playerNames.Add(name);
        }

        _matchManager = _gameManager.MatchManager;
    }

    public override void Enter()
    {
        _gameManager.GameCanvas.gameObject.SetActive(true);
        _matchManager.Initialize(_playerNames);
    }

    public override void Exit()
    {
        _gameManager.GameCanvas.gameObject.SetActive(false);
    }

    //public override void OnSceneChanged(Scene currentScene, Scene nextScene)
    //{
    //}

    public override void UpdateLogic()
    {
        _matchManager.UpdateLogic();
    }
}
