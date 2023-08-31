using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Title Points Application/Relative to Hour")]
public class HourRelativeTitlePointsApplicationData : TitlePointsApplicationData
{
    public TitlePointsId titlePointsId;
    public int minValue;
    public int maxValue;
    public int hoursToGetMaxValue;

    public override TitlePointsApplication Application(TableTurnCardState cardState)
    {
        return new HourRelativeTitlePointsApplication(cardState, eventApplication, titlePointsId, minValue, maxValue, hoursToGetMaxValue);
    }
}
