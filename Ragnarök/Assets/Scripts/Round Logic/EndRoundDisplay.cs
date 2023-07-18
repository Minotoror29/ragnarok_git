using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndRoundDisplay : MonoBehaviour
{
    private RoundEndState _state;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI winnersText;
    [SerializeField] private Button nextRoundButton;
    [SerializeField] private Button seeMatchResultsButton;

    public void Initialize(RoundEndState state)
    {
        _state = state;
    }

    public void SetTitle(int roundNumber)
    {
        title.text = "Round " + roundNumber + " is over";
    }

    public void SetWinnerText(List<Player> winners)
    {
        List<string> winnerNames = new();

        foreach (Player player in winners)
        {
            winnerNames.Add(player.PlayerName);
        }

        if (winnerNames.Count == 0)
        {
            winnersText.text = "Nobody wins the round";
        } else if (winnerNames.Count == 1)
        {
            winnersText.text = winnerNames[0] + " wins the round";
        } else if (winnerNames.Count > 1)
        {
            string names = "";

            for (int i = 0; i < winnerNames.Count; i++)
            {
                if (i == winnerNames.Count - 1)
                {
                    names += winnerNames[i];
                }
                else if (i == winnerNames.Count - 2)
                {
                    names += winnerNames[i] + " & ";
                }
                else
                {
                    names += winnerNames[i] + ", ";
                }
            }

            winnersText.text = names + " win the round";
        }
    }

    public void SetButton(bool isMatchOver)
    {
        if (!isMatchOver)
        {
            nextRoundButton.gameObject.SetActive(true);
            seeMatchResultsButton.gameObject.SetActive(false);
        } else
        {
            nextRoundButton.gameObject.SetActive(false);
            seeMatchResultsButton.gameObject.SetActive(true);
        }
    }

    public void NextRound()
    {
        _state.NextRound();
    }

    public void EndMatch()
    {
        _state.Endmatch();
    }
}
