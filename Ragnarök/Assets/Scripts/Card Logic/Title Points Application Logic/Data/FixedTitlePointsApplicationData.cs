using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Title Points Application/Fixed")]
public class FixedTitlePointsApplicationData : TitlePointsApplicationData
{
    public TitlePointsId titlePointsId;
    public int value;

    public override TitlePointsApplication Application(TableTurnManager tableTurnManager)
    {
        return new FixedTitlePointsApplication(titlePointsId, value);
    }
}
