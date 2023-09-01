using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Title Points Application/Relative to Target Points")]
public class TargetPointsRelativeTitlePointsApplicationData : TitlePointsApplicationData
{
    public TitlePointsId titlePointsId;
    public int superiorValue;
    public int equalValue;
    public int inferiorValue;

    public override TitlePointsApplication Application(TableTurnCardState cardState)
    {
        return new TargetPointsRelativeTitlePointsApplication(cardState, titlePointsId, superiorValue, equalValue, inferiorValue);
    }
}
