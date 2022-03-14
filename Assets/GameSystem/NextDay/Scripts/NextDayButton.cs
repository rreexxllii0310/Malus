using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDayButton : MonoBehaviour
{
    public DayTime dayTime;
    public GameObject nextDayMenu;
    public GameObject lastDayMenu;

    public void ShowMenu()
    {
        if (dayTime.IsLastDay())
        {
            lastDayMenu.SetActive(true);
        }
        else
        {
            nextDayMenu.SetActive(true);
        }
    }
}
