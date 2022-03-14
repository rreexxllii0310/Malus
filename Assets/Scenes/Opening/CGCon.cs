using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using titleCon;

public class CGCon : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer[] pics = new SpriteRenderer[5];
    GameObject[] picObj = new GameObject[5];
    GameObject white;
    AudioSource [] SE;
    public UnityEngine.UI.Text TitleText;
    int picIndex = 0;
    int enterCounter;

    void Start()
    {
        picObj[0] = GameObject.Find("Opening");
        picObj[1] = GameObject.Find("Opening2");
        picObj[2] = GameObject.Find("Opening3");
        picObj[3] = GameObject.Find("Opening4");
        picObj[4] = GameObject.Find("Opening5");

        white = GameObject.Find("White");
        SE = GameObject.Find("SE").GetComponents<AudioSource>();

        for (int i =0; i<5; i+=1){
            pics[i] = picObj[i].GetComponent<SpriteRenderer>();
            pics[i].color = new Color(1,1,1,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (enterCounter==0) SE[1].Play();
            if (enterCounter==9) SE[2].Play();
            if (enterCounter==11) {
                SE[2].Pause();
                SE[3].Play();
            }
            if (enterCounter==12){
                SE[3].Pause();
                SE[4].Play();
            }
            enterCounter++;
            Debug.Log(enterCounter);
        }
        if (enterCounter==0){
            TitleText.color = new Color(1,1,1,1);
        }
        if (enterCounter==1) 
        {
             
            TitleText.color = new Color(1,1,1,0);
            pics[0].color = new Color(1,1,1,1);
        }
        if (enterCounter==10){
             pics[1].color = new Color(1,1,1,1);
             pics[0].color = new Color(1,1,1,0);
             TitleText.color = new Color(0,0,0,0);
             TitleText.text = "M  a  l  u  s";
        }
        if (enterCounter == 11){
            Color tmpWhite = white.GetComponent<SpriteRenderer>().color;
            Color tmpTitle = TitleText.color;
            tmpWhite.a = tmpWhite.a+0.002f;
            tmpTitle.a = tmpTitle.a+0.002f;
            white.GetComponent<SpriteRenderer>().color = tmpWhite;
            TitleText.color = tmpTitle;
        }
        if (enterCounter == 12){
            pics[1].color = new Color(1,1,1,0);
             TitleText.color = new Color(1,1,1,0);
             Color tmpWhite = white.GetComponent<SpriteRenderer>().color;
              tmpWhite.a = tmpWhite.a-0.0075f;
            white.GetComponent<SpriteRenderer>().color = tmpWhite;
            pics[2].color = new Color(1,1,1,1);
        }
        if (enterCounter == 13){
            pics[2].color = new Color(1,1,1,0);
            pics[3].color = new Color(1,1,1,1);
        }
       if (enterCounter == 26){
            pics[4].color = new Color(1,1,1,1);
            pics[3].color = new Color(1,1,1,0);
        }
        if (enterCounter == 27) {
            //SceneChange
            SceneManager.LoadScene("RocketScene");
        }
    }
}
