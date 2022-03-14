using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Map Region", menuName = "Map/Map Region")]
public class MapRegionSO : ScriptableObject
{
    public string regionName;
    public Sprite regionSprite;
    public Sprite lockedSprite;
    
    public bool isHere = false;
    public bool isLocked = true;
    public bool isLockedYesterday = true;

    public bool isReachable = false;
    public int timesHere = 0;

    public List<MapRegionSO> neighborRegions = new List<MapRegionSO>();


}
