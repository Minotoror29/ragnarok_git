using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Title Points Application/Relative to Target Wealth")]
public class TargetWealthRelativeTitlePointsApplicationData : TitlePointsApplicationData
{
    public TitlePointsId titlePointsId;
    public int poorValue;
    public int neutralValue;
    public int richValue;

    public override TitlePointsApplication Application(TableTurnCardState cardState)
    {
        return new TargetWealthRelativeTitlePointsApplication(cardState, titlePointsId, poorValue, neutralValue, richValue);
    }
}
