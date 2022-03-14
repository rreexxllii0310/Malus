using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyaNPCController : MonoBehaviour
{
    public GameObject Trigger;

    // Update is called once per frame
    void Update()
    {
        if (!Trigger.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
    }
}
