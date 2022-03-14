using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyaHouseExit : MonoBehaviour
{
    public MapRegionSO villageRegionSO;
    public AnyaHouseSO anyaHouseSO;
    public void ExitHouse() 
    {
        // 出去 Anya 家不多算進去村莊一次
        villageRegionSO.timesHere -= 1;
        anyaHouseSO.isExitAnyaHouse = true;
        SceneManager.LoadScene("VillageScene");
    }
}
