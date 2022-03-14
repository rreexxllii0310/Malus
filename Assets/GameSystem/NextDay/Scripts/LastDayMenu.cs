using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastDayMenu : MonoBehaviour
{
    public void GoToDecisionScene(){
        //SceneManager.LoadScene("DecisionScene");
        SceneManager.LoadScene("Ending");
    }
}
