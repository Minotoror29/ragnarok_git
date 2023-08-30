using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TitlePointsApplicationData : ScriptableObject
{
    public abstract TitlePointsApplication Application(TableTurnManager tableTurnManager);
}
