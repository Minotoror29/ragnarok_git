using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableTurnIndicator : MonoBehaviour
{
    [SerializeField] private Image activeImage;
    [SerializeField] private Image inactiveImage;

    public void SetActive()
    {
        inactiveImage.gameObject.SetActive(false);
        activeImage.gameObject.SetActive(true);
    }

    public void SetInactive()
    {
        activeImage.gameObject.SetActive(false);
        inactiveImage.gameObject.SetActive(true);
    }
}
