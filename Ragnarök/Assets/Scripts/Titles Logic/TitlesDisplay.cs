using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlesDisplay : MonoBehaviour
{
    [SerializeField] private PlayerTitleDisplay playerTitlePrefab;
    [SerializeField] private Transform playerTitlesParent;

    public void DetermineTitles(List<Player> players)
    {
        foreach (Player player in players)
        {
            PlayerTitleDisplay newTitleDisplay = Instantiate(playerTitlePrefab, playerTitlesParent);
        }
    }
}
