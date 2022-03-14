using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageTriggerManager : MonoBehaviour
{
    public MapManager mapManager;
    public GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {
        // Project setting: this script should execute after map manager
        if(mapManager.GetTimesHere()>1)
        {
            Debug.Log("active");
            Trigger.SetActive(false);
        }
    }
}
