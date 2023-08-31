using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Title Points Application/Fixed")]
public class FixedTitlePointsApplicationData : TitlePointsApplicationData
{
    public TitlePointsId titlePointsId;
    public int value;

    public override TitlePointsApplication Application(TableTurnCardState cardState)
    {
        return new FixedTitlePointsApplication(cardState, eventApplication, titlePointsId, value);
    }
}
