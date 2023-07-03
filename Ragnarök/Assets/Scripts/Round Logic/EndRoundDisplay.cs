using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndRoundDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI winnersText;

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
}
