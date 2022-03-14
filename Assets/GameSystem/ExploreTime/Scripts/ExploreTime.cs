using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExploreTime : MonoBehaviour
{
    public ExploreTimeSO exploreTimeSO;
    public Image exploreTimeImage;
    // Start is called before the first frame update
    void Start()
    {
        //+MOD
        if (SceneManager.GetActiveScene().name != "VillageScene"
            && SceneManager.GetActiveScene().name != "AnyaHouse"
            && SceneManager.GetActiveScene().name != "RocketScene")
        {
            exploreTimeSO.CurrentExploreTime -= 1;
        }
        exploreTimeImage.sprite = exploreTimeSO.exploreTimeSprites[exploreTimeSO.CurrentExploreTime];
        Debug.Log("Start Explore Time Manager!");
    }

    public void ResetToInitial()
    {
        exploreTimeSO.CurrentExploreTime = 3;
    }

    public void UseExploreTime(int times)
    {
        exploreTimeSO.CurrentExploreTime -= times;
        exploreTimeImage.sprite = exploreTimeSO.exploreTimeSprites[exploreTimeSO.CurrentExploreTime];
    }

    public void ResetExploreTime()
    {
        exploreTimeSO.CurrentExploreTime = exploreTimeSO.MaxExploreTime;
        exploreTimeImage.sprite = exploreTimeSO.exploreTimeSprites[exploreTimeSO.CurrentExploreTime];
    }

}
