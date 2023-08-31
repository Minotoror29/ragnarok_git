using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TitlePointsApplicationData : ScriptableObject
{
    public EventApplicationData eventApplication;

    public abstract TitlePointsApplication Application(TableTurnCardState cardState);
}
