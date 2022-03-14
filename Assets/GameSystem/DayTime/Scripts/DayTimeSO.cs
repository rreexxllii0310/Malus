using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Day Time", menuName = "Day Time/Day Time")]
public class DayTimeSO : ScriptableObject {
    [SerializeField]
    private int currentDayTime = 1;
    [SerializeField]
    private int maxDayTime = 7;

    public int MaxDayTime
    {
        get { return maxDayTime; }
    }

    public int CurrentDayTime
    {
        get { return currentDayTime; }
        set
        {
            currentDayTime = value;
            if (currentDayTime < 1)
            {
                currentDayTime = 1;
            }
            else if (currentDayTime > maxDayTime)
            {
                currentDayTime = maxDayTime;
            }
        }
    }
}
