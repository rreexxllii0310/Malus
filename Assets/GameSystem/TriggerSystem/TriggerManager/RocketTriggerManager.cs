using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTriggerManager : MonoBehaviour
{
    public MapManager mapManager;
    public GameObject Trigger1;
    public GameObject Trigger2;
    public GameObject Trigger3;
    public GameObject Trigger4;
    public GameObject Trigger5;
    // Start is called before the first frame update
    void Start()
    {
        // Project setting: this script should execute after map manager
        if(mapManager.GetTimesHere()>1)
        {
            Trigger1.SetActive(false);
            Trigger2.SetActive(false);
            Trigger3.SetActive(false);
            Trigger4.SetActive(false);
            Trigger5.SetActive(false);
        }
    }
}
