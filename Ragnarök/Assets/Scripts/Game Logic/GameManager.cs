using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    private StateManager _stateManager;

    [SerializeField] private PlayerSelectionManager _playerSelectionManager;
    [SerializeField] private CinemachineVirtualCamera _playerSelectionCamera;

    [SerializeField] private MatchManager matchManager;
    [SerializeField] private Canvas gameCanvas;

    public PlayerSelectionManager PlayerSelectionManager { get { return _playerSelectionManager; } }
    public CinemachineVirtualCamera PlayerSelectionCamera { get { return _playerSelectionCamera; } }
    public MatchManager MatchManager { get { return matchManager; } }
    public Canvas GameCanvas { get { return gameCanvas; } }

    [Header("TESTS ONLY")]
    [SerializeField] private List<string> playerNames;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateLogic();
    }

    public void Initialize()
    {
        _stateManager = GetComponent<StateManager>();

        //if (SceneManager.GetActiveScene().name == "PlayerSelection")
        //{
        //    _stateManager.ChangeState(new GamePlayerSelectionState(_stateManager, this));
        //} else if (SceneManager.GetActiveScene().name == "MainScene")
        //{
        //    _stateManager.ChangeState(new GameMatchState(_stateManager, this, playerNames));
        //}

        _stateManager.ChangeState(new GamePlayerSelectionState(_stateManager, this));
    }

    public void UpdateLogic()
    {
        _stateManager.UpdateLogic();
    }
}
