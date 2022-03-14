using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFirstBlock : MonoBehaviour
{
    public DayTime dayTime;

    private void Start() {
        if(dayTime.dayTimeSO.CurrentDayTime>1)
        {
            Destroy(this.gameObject);
        }
    }
}
