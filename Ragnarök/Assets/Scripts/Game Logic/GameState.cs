using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameState : State
{
    protected GameManager _gameManager;

    public GameState(StateManager stateManager, GameManager gameManager) : base(stateManager)
    {
        _gameManager = gameManager;

        SceneManager.activeSceneChanged += OnSceneChanged;
    }

    public abstract void OnSceneChanged(Scene currentScene, Scene nextScene);
}
