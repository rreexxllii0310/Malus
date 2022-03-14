using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Map Item Manager", menuName = "Map Item Manager/Map Item Manager")]
public class MapItemManagerSO : ScriptableObject
{
    public Dictionary<string, bool[]> name_state_mapping = new Dictionary<string, bool[]>(){
        {"VillageScene", new bool[]{}},
        {"ExploreAScene", new bool[]{false, false, false, false, false}},
        {"ExploreBScene", new bool[]{}},
        {"ExploreCScene", new bool[]{false, false, false, false, false, false, false, false}},
        {"RocketScene", new bool[]{false, false}}
    };
}
