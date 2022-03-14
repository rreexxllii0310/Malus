using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapItemManager : MonoBehaviour
{
    public MapItemManagerSO mapItemManagerSO;
    public List<MapItem> mapItems = new List<MapItem>();


    private void Awake()
    {
        string scene_name = SceneManager.GetActiveScene().name;
        SetState(scene_name);
        DestroyPicked();
    }

    public void ResetToInitial()
    {
        foreach (KeyValuePair<string, bool[]> kvp in mapItemManagerSO.name_state_mapping)
        {
            for (int i = 0; i < kvp.Value.Length; i++)
            {
                kvp.Value[i] = false;
            }

        }
    }

    public void SetState(string scene_name)
    {
        for (int i = 0; i < mapItems.Count; i++)
        {
            mapItems[i].Idx = i;
            mapItems[i].IsPicked = mapItemManagerSO.name_state_mapping[scene_name][i];
        }
    }

    public void SetPicked(string scene_name, int idx)
    {
        mapItemManagerSO.name_state_mapping[scene_name][idx] = true;
    }

    public void DestroyPicked()
    {
        //Debug.Log("DESTORY");
        foreach (MapItem mapItem in mapItems)
        {
            if (mapItem.IsPicked)
            {
                Destroy(mapItem.gameObject);
            }
        }
    }


}
