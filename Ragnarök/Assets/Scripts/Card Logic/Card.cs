using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public EffectData effect1;
    public EffectData effect2;
    public int duplicates;
    public bool vote = false;
}
