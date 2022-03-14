using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class END4 : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEngine.UI.Text storyText;
    public UnityEngine.UI.Text END;
    AudioSource [] SE;
    SpriteRenderer Uni;
    SpriteRenderer Blue;
     int enterCnt;
    void Start()
    {
        SE = GameObject.Find("SE").GetComponents<AudioSource>();
        Uni = GameObject.Find("Uni").GetComponent<SpriteRenderer>();
        Blue = GameObject.Find("Square").GetComponent<SpriteRenderer>();
        END.color = new Color(1,1,1,0);
        Uni.color = new Color(1,1,1,0);
        Color tmp = Blue.color;
        tmp.a=0;
        Blue.color = tmp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            enterCnt ++;
            Debug.Log(enterCnt);
        }
        if(enterCnt==6){
            SE[2].Play();
        }
        if(enterCnt==7){
            Uni.color = new Color(1,1,1,1);
            SE[3].Play();
        }
        if(enterCnt==8){
            Uni.color = new Color(1,1,1,0);
        }
        if(enterCnt==19){
            SE[4].Play();
        }
        if(enterCnt==26){
            SE[0].Pause();
            SE[2].Play();
            SE[1].Play();
        }
        if(enterCnt==27){
            Color tmp = Blue.color;
            tmp.a=1;
            Blue.color = tmp;
        }
        if(enterCnt==42){
           Color tmp = Blue.color;
            tmp.a=0;
            Blue.color = tmp;
            END.color = new Color(1,1,1,1);
            storyText.color = new Color(1,1,1,0);
        }
        if(enterCnt==43){
            //SceneChange
            SceneManager.LoadScene("StartMenuScene");
        }
    }
}
