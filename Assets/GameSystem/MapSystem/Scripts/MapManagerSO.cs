using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Manager", menuName = "Map/Map Manager")]
public class MapManagerSO : ScriptableObject
{
    public List<MapRegionSO> mapRegions = new List<MapRegionSO>();
}
