using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetSO : MonoBehaviour
{
    public MapManager mapManager;
    public DayTime dayTime;
    public ExploreTime exploreTime;
    public ImportantItem importantItem;
    public MapItemManager mapItemManager;
    public NPCManager npcManager;

    public void  ResetAllToInitial()
    {
        mapManager.ResetToInitial();
        dayTime.ResetToInitial();
        exploreTime.ResetToInitial();
        importantItem.ResetToInitial();
        mapItemManager.ResetToInitial();
        npcManager.ResetToInitial();
    }

}
