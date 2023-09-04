using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Title Points Application/Relative to Custom Value")]
public class CustomValueRelativeTitlePointsApplicationData : TitlePointsApplicationData
{
    public TitlePointsId titlePointsId;

    public override TitlePointsApplication Application(TableTurnCardState cardState)
    {
        return new CustomValueRelativeTitlePointsApplication(cardState, titlePointsId);
    }
}
