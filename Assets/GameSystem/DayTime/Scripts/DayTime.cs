using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayTime : MonoBehaviour
{
    public DayTimeSO dayTimeSO;

    public TMP_Text dayTimeText;

    private void Start()
    {
        SetDayTime(dayTimeSO.CurrentDayTime);
    }

    public void ResetToInitial()
    {
        dayTimeSO.CurrentDayTime = 1;
    }

    public void SetDayTime(int day)
    {
        dayTimeText.text = "Day " + day.ToString();
    }

    public void AddDayTime(int dayTime)
    {
        dayTimeSO.CurrentDayTime += 1;
        SetDayTime(dayTimeSO.CurrentDayTime);
    }

    public bool IsLastDay(){
        return (dayTimeSO.CurrentDayTime == dayTimeSO.MaxDayTime);
    }
}
