using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public void GoRocket()
    {
        SceneManager.LoadScene("RocketScene");
    }
    public void GoVillage()
    {
        SceneManager.LoadScene("VillageScene");
    }
    public void GoExploreA()
    {
        SceneManager.LoadScene("ExploreAScene");
    }

    public void GoExploreB()
    {
        SceneManager.LoadScene("ExploreBScene");
    }

    public void GoExploreC()
    {
        SceneManager.LoadScene("ExploreCScene");
    }

}
