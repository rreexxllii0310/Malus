using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private MapManagerSO mapManagerSO;

    [SerializeField]
    private MapRegionSO currentMapRegionSO;

    [SerializeField]
    private ExploreTimeSO exploreTimeSO;

    private Scene currentScene;

    public Location locationText;
    public TimesHere timesHereText;
    public ExploreTime exploreTime;

    void Start()
    {
        //The map manager SO (map regions index) should be (scene index-1) in build setting
        if (SceneManager.GetActiveScene().name == "AnyaHouse")
        {
            // If in Anya House, set current region to Village
            currentMapRegionSO = mapManagerSO.mapRegions[1];
            Debug.Log("AnyaHouse");
            locationText.hintText.text = "AnyaHouse";
        }
        else
        {
            currentMapRegionSO = mapManagerSO.mapRegions[SceneManager.GetActiveScene().buildIndex - 1];
            Debug.Log(currentMapRegionSO.name);
            //locationText.hintText.text = currentMapRegionSO.name + " scene";
            locationText.hintText.text = currentMapRegionSO.name;
            //Check how many times arrive at this current scene
            currentMapRegionSO.timesHere += 1;
            //timesHereText.hintText.text = currentMapRegionSO.timesHere.ToString() + " times here";

            // Game Start: do not count the explore time
            if (currentMapRegionSO.name == "Rocket" && currentMapRegionSO.timesHere == 1)
            {
                exploreTime.ResetExploreTime();
            }

            // New day begin: Load yesterday's map region lock state
            if (exploreTimeSO.CurrentExploreTime == exploreTimeSO.MaxExploreTime)
            {
                NewDaySetting();
            }
            CheckExploreSetting();
        }
    }

    public void ResetToInitial()
    {
        foreach (MapRegionSO mapRegionSO in mapManagerSO.mapRegions)
        {
            mapRegionSO.isHere = false;
            mapRegionSO.isLocked = true;
            mapRegionSO.isLockedYesterday = true;
            mapRegionSO.isReachable = false;
            mapRegionSO.timesHere = 0;
        }
    }

    public void NewDaySetting()
    {
        Debug.Log("New day");
        _reloadYesterdayLockState();
    }

    public void CheckExploreSetting()
    {
        // If player still has the explore times
        if (exploreTimeSO.CurrentExploreTime != 0)
        {
            ExploreSetting();
        }
        else // If player has NO explore times
        {
            NoExploreSetting();
        }
    }

    public void ExploreSetting()
    {
        Debug.Log("Explore");
        _resetAllState();
        _setCurrentState();
        _setNeighborState();
    }

    public void NoExploreSetting()
    {
        Debug.Log("NO Explore");
        _resetAllState();
        _setCurrentState();

        // Record today's map region lock states for tomorrow reload
        // before locking all map regions 
        _recordLockState();

        // Explore times have use up, cannot go anywhere
        _lockAllRegion();
    }

    public int GetTimesHere()
    {
        return currentMapRegionSO.timesHere;
    }

    private void _resetAllState()
    {
        foreach (MapRegionSO mapRegionSO in mapManagerSO.mapRegions)
        {
            mapRegionSO.isHere = false;
            mapRegionSO.isReachable = false;
        }
    }

    private void _setCurrentState()
    {
        currentMapRegionSO.isHere = true;
        currentMapRegionSO.isLocked = false;
        currentMapRegionSO.isReachable = true;
    }

    private void _setNeighborState()
    {
        foreach (MapRegionSO mapRegionSO in currentMapRegionSO.neighborRegions)
        {
            mapRegionSO.isReachable = true;
        }
    }

    private void _recordLockState()
    {
        foreach (MapRegionSO mapRegionSO in mapManagerSO.mapRegions)
        {
            mapRegionSO.isLockedYesterday = mapRegionSO.isLocked;
        }
    }

    private void _reloadYesterdayLockState()
    {
        foreach (MapRegionSO mapRegionSO in mapManagerSO.mapRegions)
        {
            mapRegionSO.isLocked = mapRegionSO.isLockedYesterday;
        }
    }

    private void _lockAllRegion()
    {
        foreach (MapRegionSO mapRegionSO in mapManagerSO.mapRegions)
        {
            mapRegionSO.isLocked = true;
        }
    }

}
