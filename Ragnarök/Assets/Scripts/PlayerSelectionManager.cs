using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelectionManager : MonoBehaviour
{
    private static PlayerSelectionManager instance;
    public static PlayerSelectionManager Instance => instance;

    private GamePlayerSelectionState _state;

    [SerializeField] private List<TMP_InputField> playerNameInputFields;

    private void Awake()
    {
        instance = this;
    }

    public void Initialize(GamePlayerSelectionState state)
    {
        _state = state;
    }

    public void StartMatch()
    {
        List<string> playerNames = new();
        foreach (TMP_InputField field in playerNameInputFields)
        {
            playerNames.Add(field.text);
        }
        _state.SetPlayerNames(playerNames);

        SceneManager.LoadScene(1);
    }

    public void AddPlayer(TMP_InputField inputField)
    {
        playerNameInputFields.Add(inputField);
    }

    public void RemovePlayer(TMP_InputField inputField)
    {
        playerNameInputFields.Remove(inputField);
    }
}
