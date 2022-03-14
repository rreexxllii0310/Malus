using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterHouseBtn : MonoBehaviour
{
    public void EnterHouse() 
    {
        SceneManager.LoadScene("AnyaHouse");
    }
}
