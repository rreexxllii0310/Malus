using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextDayMenu : MonoBehaviour
{
    public DayTime dayTime;
    public ExploreTime exploreTime;
    public void StartNewDay()
    {
        //Start new day from village
        SceneManager.LoadScene("VillageScene");

        //Add day count
        dayTime.AddDayTime(1);

        //Reset explore time
        exploreTime.ResetExploreTime();
    }
    
}
