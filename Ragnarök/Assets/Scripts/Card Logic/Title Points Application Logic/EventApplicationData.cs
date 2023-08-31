using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventApplicationData : ScriptableObject
{
    public abstract void AssignEvent(TableTurnCardState cardState, Action<Player> OnPlayerAdded);
    public abstract void UnassignEvent(TableTurnCardState cardState, Action<Player> OnPlayerAdded);
}
