using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Effect effect1;
    public Effect effect2;
    public bool vote = false;
}
