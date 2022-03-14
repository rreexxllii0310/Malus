using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class END1 : MonoBehaviour
{
    // Start is called before the first frame update
    int enterCnt;
    public UnityEngine.UI.Text storyText;
    AudioSource [] SE;
    GameObject red;
    SpriteRenderer CG;
    void Start()
    {
        SE = GameObject.Find("SE").GetComponents<AudioSource>();
        red = GameObject.Find("Square");
        CG = GameObject.Find("END1title").GetComponent<SpriteRenderer>();
        CG.color = new Color(1,1,1,0);
        Color tmp = red.GetComponent<SpriteRenderer>().color;
        tmp.a = 0f;
        red.GetComponent<SpriteRenderer>().color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))    {
            enterCnt++;
            if(enterCnt==6) SE[2].Play();
            if(enterCnt == 9) SE[2].Pause();
            if(enterCnt == 11) SE[3].Play();
            if(enterCnt == 13) SE[3].Pause();
            Debug.Log(enterCnt);
        }
        if(enterCnt==7){
            SE[0].Pause();
            Color tmp = red.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            red.GetComponent<SpriteRenderer>().color = tmp;
        }
        if(enterCnt == 14){
            Color tmp = GameObject.Find("END1title").GetComponent<SpriteRenderer>().color;
            tmp.a += 0.005f;
            CG.color = tmp;
        }
        if(enterCnt == 15){
            CG.color = new Color(1,1,1,1);
        }
        if(enterCnt ==16){
            SceneManager.LoadScene("StartMenuScene");
        }
    }
}
