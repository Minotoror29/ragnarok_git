using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TitlesDisplay : MonoBehaviour
{
    [SerializeField] private PlayerTitleDisplay playerTitlePrefab;
    [SerializeField] private Transform playerTitlesParent;

    private List<Player> _playersToAttributeTitle;
    private Dictionary<Player, List<TitleData>> _playersTitles;

    [SerializeField] private TitleData winnerTitle;
    [SerializeField] private TitleData developingCountryTitle;
    [SerializeField] private TitleData suppositTitle;
    [SerializeField] private TitleData welfareStateTitle;
    [SerializeField] private TitleData neutralTitle;
    [SerializeField] private TitleData imperialistTitle;
    [SerializeField] private TitleData martyrTitle;
    [SerializeField] private TitleData climateSkepticTitle;
    [SerializeField] private TitleData agentOfExtinctionTitle;
    [SerializeField] private TitleData decayingTitle;
    [SerializeField] private TitleData industrialTitle;
    [SerializeField] private TitleData insignificantTitle;

    public void DetermineTitles(List<Player> players, List<Player> winners)
    {
        _playersToAttributeTitle = new();
        _playersTitles = new Dictionary<Player, List<TitleData>>();
        foreach (Player player in players)
        {
            _playersToAttributeTitle.Add(player);
            _playersTitles.Add(player, new List<TitleData>());
        }

        AssignWinnerTitle(winners);
        if (_playersToAttributeTitle.Count == 0) { return; }
        AssignDevelopingCountryTitle();
        AssignMartyrTitle();
        AssignClimateSkepticTitle();
        AssignAgentOfExtinctionTitle();
        AssignDecayingTitle();
        AssignIndustrialTitle();
        AssignSuppositTitle();
        AssignWelfareStateTitle();
        AssignNeutralTitle();
        AssignImperialistTitle();
        AssignInsignificantTitle();

        AssignFinalTitles();
    }

    private void AssignWinnerTitle(List<Player> winners)
    {
        if (winners.Count == 1)
        {
            CreateNewTitle(winners[0], winnerTitle);
            _playersToAttributeTitle.Remove(winners[0]);
            _playersTitles.Remove(winners[0]);
        }
        else
        {
            int highestTotalPower = 0;

            foreach (Player player in winners)
            {
                if (player.Points > highestTotalPower)
                {
                    highestTotalPower = player.Points;
                }
            }

            foreach (Player player in winners)
            {
                if (player.Points == highestTotalPower)
                {
                    CreateNewTitle(player, winnerTitle);
                    _playersToAttributeTitle.Remove(player);
                    _playersTitles.Remove(player);
                }
            }
        }
    }

    private void AssignDevelopingCountryTitle()
    {
        int lowestTotalPower = 0;
        for (int i = 0; i < _playersToAttributeTitle.Count; i++)
        {
            if (_playersToAttributeTitle[i].RoundsWon == 0)
            {
                if (i == 0)
                {
                    lowestTotalPower = _playersToAttributeTitle[i].Points;
                }
                else
                {
                    if (_playersToAttributeTitle[i].Points < lowestTotalPower)
                    {
                        lowestTotalPower = _playersToAttributeTitle[i].Points;
                    }
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.RoundsWon == 0)
            {
                if (player.Points == lowestTotalPower)
                {
                    _playersTitles[player].Add(developingCountryTitle);
                    Debug.Log("Assigning Developing Country title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignSuppositTitle()
    {
        int lowestAssistanceScore = 0;
        for (int i = 0; i < _playersToAttributeTitle.Count; i++)
        {
            if (_playersToAttributeTitle[i].TitlePoints[TitlePointsId.Assistance] < 0)
            {
                if (i == 0)
                {
                    lowestAssistanceScore = _playersToAttributeTitle[i].TitlePoints[TitlePointsId.Assistance];
                } else
                {
                    if (_playersToAttributeTitle[i].TitlePoints[TitlePointsId.Assistance] < lowestAssistanceScore)
                    {
                        lowestAssistanceScore = _playersToAttributeTitle[i].TitlePoints[TitlePointsId.Assistance];
                    }
                }
            }
        }

        foreach(Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Assistance] < 0)
            {
                if (player.TitlePoints[TitlePointsId.Assistance] == lowestAssistanceScore)
                {
                    _playersTitles[player].Add(suppositTitle);
                    Debug.Log("Assigning Supposit title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignWelfareStateTitle()
    {
        int highestAssistanceScore = 0;
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Assistance] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Assistance] > highestAssistanceScore)
                {
                    highestAssistanceScore = player.TitlePoints[TitlePointsId.Assistance];
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Assistance] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Assistance] == highestAssistanceScore)
                {
                    _playersTitles[player].Add(welfareStateTitle);
                    Debug.Log("Assigning Welfare State title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignNeutralTitle()
    {
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Imperialism] == 0)
            {
                _playersTitles[player].Add(neutralTitle);
                Debug.Log("Assigning Neutral title to " + player.PlayerName);
            }
        }
    }

    private void AssignImperialistTitle()
    {
        int highestImperialismScore = 0;
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Imperialism] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Imperialism] > highestImperialismScore)
                {
                    highestImperialismScore = player.TitlePoints[TitlePointsId.Imperialism];
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Imperialism] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Imperialism] == highestImperialismScore)
                {
                    _playersTitles[player].Add(imperialistTitle);
                    Debug.Log("Assigning Imperialist title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignMartyrTitle()
    {
        int highestMartyrScore = 0;
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Martyr] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Martyr] > highestMartyrScore)
                {
                    highestMartyrScore = player.TitlePoints[TitlePointsId.Martyr];
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Martyr] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Martyr] == highestMartyrScore)
                {
                    _playersTitles[player].Add(martyrTitle);
                    Debug.Log("Assigning Martyr title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignClimateSkepticTitle()
    {
        int highestRagnarokScore = 0;
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Ragnarok] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Ragnarok] > highestRagnarokScore)
                {
                    highestRagnarokScore = player.TitlePoints[TitlePointsId.Ragnarok];
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Ragnarok] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Ragnarok] == highestRagnarokScore)
                {
                    _playersTitles[player].Add(climateSkepticTitle);
                    Debug.Log("Assigning Climate Skeptic title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignAgentOfExtinctionTitle()
    {
        int highestExtinctionScore = 0;
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Extinction] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Extinction] > highestExtinctionScore)
                {
                    highestExtinctionScore = player.TitlePoints[TitlePointsId.Extinction];
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Extinction] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Extinction] == highestExtinctionScore)
                {
                    _playersTitles[player].Add(agentOfExtinctionTitle);
                    Debug.Log("Assigning Agent of Extinction title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignDecayingTitle()
    {
        int lowestProductivismScore = 0;
        for (int i = 0; i < _playersToAttributeTitle.Count; i++)
        {
            if (_playersToAttributeTitle[i].TitlePoints[TitlePointsId.Productivism] < 0)
            {
                if (i == 0)
                {
                    lowestProductivismScore = _playersToAttributeTitle[i].TitlePoints[TitlePointsId.Productivism];
                }
                else
                {
                    if (_playersToAttributeTitle[i].TitlePoints[TitlePointsId.Productivism] < lowestProductivismScore)
                    {
                        lowestProductivismScore = _playersToAttributeTitle[i].TitlePoints[TitlePointsId.Productivism];
                    }
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Productivism] < 0)
            {
                if (player.TitlePoints[TitlePointsId.Productivism] == lowestProductivismScore)
                {
                    _playersTitles[player].Add(decayingTitle);
                    Debug.Log("Assigning Decaying title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignIndustrialTitle()
    {
        int highestProductivismScore = 0;
        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Productivism] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Productivism] > highestProductivismScore)
                {
                    highestProductivismScore = player.TitlePoints[TitlePointsId.Productivism];
                }
            }
        }

        foreach (Player player in _playersToAttributeTitle)
        {
            if (player.TitlePoints[TitlePointsId.Productivism] > 0)
            {
                if (player.TitlePoints[TitlePointsId.Productivism] == highestProductivismScore)
                {
                    _playersTitles[player].Add(industrialTitle);
                    Debug.Log("Assigning Industrial title to " + player.PlayerName);
                }
            }
        }
    }

    private void AssignInsignificantTitle()
    {
        foreach (Player player in _playersToAttributeTitle)
        {
            if (_playersTitles[player].Count == 0)
            {
                CreateNewTitle(player, insignificantTitle);
                _playersTitles.Remove(player);
            }
        }
    }

    private void AssignFinalTitles()
    {
        while (_playersTitles.Count > 0)
        {
            //Determine highest priority amongst players' titles
            int highestPriority = 7;
            foreach (KeyValuePair<Player, List<TitleData>> entry in _playersTitles)
            {
                if (entry.Value[0].priority < highestPriority)
                {
                    highestPriority = entry.Value[0].priority;
                }
            }

            //Take one of the highest priority titles
            string titleToCheck = "";
            foreach (KeyValuePair<Player, List<TitleData>> entry in _playersTitles)
            {
                if (entry.Value[0].priority == highestPriority)
                {
                    titleToCheck = entry.Value[0].titleName;
                    break;
                }
            }

            //Check if that title has duplicates
            List<Player> duplicates = new();
            foreach (KeyValuePair<Player, List<TitleData>> entry in _playersTitles)
            {
                if (entry.Value[0].titleName == titleToCheck)
                {
                    duplicates.Add(entry.Key);
                }
            }

            //If there are no duplicates, create the title display and remove the player from the dictionary
            if (duplicates.Count == 1)
            {
                CreateNewTitle(duplicates[0], _playersTitles[duplicates[0]][0]);
                _playersTitles.Remove(duplicates[0]);
            }
            //If there are duplicates, check the following titles to find one with a smaller priority
            else if (duplicates.Count > 1)
            {
                //Check if duplicates have other titles possible
                List<Player> duplicatesThatHaveOtherTitles = new();
                foreach (Player player in duplicates)
                {
                    if (_playersTitles[player].Count > 1)
                    {
                        duplicatesThatHaveOtherTitles.Add(player);
                    }
                }

                //If there are none then create the title display and remove the player from the dictionary
                if (duplicatesThatHaveOtherTitles.Count == 0)
                {
                    foreach (Player player in duplicates)
                    {
                        CreateNewTitle(player, _playersTitles[player][0]);
                        _playersTitles.Remove(player);
                    }
                }
                else
                {
                    //Determine second highest priority amongst players' titles
                    int secondHighestPriority = 7;
                    foreach (Player player in duplicatesThatHaveOtherTitles)
                    {
                        if (_playersTitles[player][1].priority < secondHighestPriority)
                        {
                            secondHighestPriority = _playersTitles[player][1].priority;
                        }
                    }

                    //Check if there are the same amount of same second titles
                    List<Player> duplicatesWithSecondPriority = new();
                    foreach (Player player in duplicatesThatHaveOtherTitles)
                    {
                        if (_playersTitles[player][1].priority == secondHighestPriority)
                        {
                            duplicatesWithSecondPriority.Add(player);
                        }
                    }

                    //If there are the higher priority title that is removed is decided at random
                    if (duplicatesWithSecondPriority.Count == duplicates.Count)
                    {
                        int randomPlayer = Random.Range(0, duplicatesWithSecondPriority.Count);
                        _playersTitles[duplicatesWithSecondPriority[randomPlayer]].Remove(_playersTitles[duplicatesWithSecondPriority[randomPlayer]][0]);
                    } else
                    {
                        //Else remove them all
                        foreach (Player player in duplicatesWithSecondPriority)
                        {
                            _playersTitles[player].Remove(_playersTitles[player][0]);
                        }
                    }
                }
            }
        }
    }

    private void CreateNewTitle(Player player, TitleData title)
    {
        PlayerTitleDisplay newTitleDisplay = Instantiate(playerTitlePrefab, playerTitlesParent);
        newTitleDisplay.Initialize(player.PlayerName, title.titleName);
    }
}
