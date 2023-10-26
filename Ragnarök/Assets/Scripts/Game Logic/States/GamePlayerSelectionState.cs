using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayerSelectionState : GameState
{
    private List<string> _playerNames;
    private Transform _camRotationCenter;
    private float _camRotationSpeed;

    public GamePlayerSelectionState(StateManager stateManager, GameManager gameManager) : base(stateManager, gameManager)
    {
        _camRotationCenter = _gameManager.PlayerSelectionCamera.transform.parent;
        _camRotationSpeed = _gameManager.PlayerSelectionManager.CamRotationSpeed;
    }

    public override void Enter()
    {
        _gameManager.PlayerSelectionCamera.gameObject.SetActive(true);
        _gameManager.PlayerSelectionManager.gameObject.SetActive(true);
        _gameManager.PlayerSelectionManager.Initialize(this);
    }

    public override void Exit()
    {
        _gameManager.PlayerSelectionCamera.gameObject.SetActive(false);
        _gameManager.PlayerSelectionManager.gameObject.SetActive(false);
    }

    public override void UpdateLogic()
    {
        Vector3 camRotation = new Vector3(0f, _camRotationSpeed, 0f) * Time.deltaTime;
        _camRotationCenter.Rotate(camRotation);
    }

    //public override void OnSceneChanged(Scene currentScene, Scene nextScene)
    //{
    //    if (SceneManager.GetActiveScene().buildIndex == 1)
    //    {
    //        _stateManager.ChangeState(new GameMatchState(_stateManager, _gameManager, _playerNames));
    //    }
    //}

    //public void SetPlayerNames(List<string> playerNames)
    //{
    //    _playerNames = new();

    //    foreach (string playerName in playerNames)
    //    {
    //        _playerNames.Add(playerName);
    //    }
    //}

    public void StartMatch(List<string> playerNames)
    {
        _playerNames = new();
        foreach (string playerName in playerNames)
        {
            _playerNames.Add(playerName);
        }

        _stateManager.ChangeState(new GameMatchState(_stateManager, _gameManager, _playerNames));
    }
}
