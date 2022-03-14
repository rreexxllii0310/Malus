using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class END3 : MonoBehaviour
{
    // Start is called before the first frame update
    int enterCnt;
    public UnityEngine.UI.Text storyText;
    AudioSource [] SE;
    SpriteRenderer CG;
    SpriteRenderer Uni;
    void Start()
    {
        SE = GameObject.Find("SE").GetComponents<AudioSource>();
        CG = GameObject.Find("END3").GetComponent<SpriteRenderer>();
        Uni = GameObject.Find("Uni").GetComponent<SpriteRenderer>();
        CG.color = new Color(1,1,1,0);
        Uni.color = new Color(1,1,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            enterCnt ++;
            Debug.Log(enterCnt);
        }
        if(enterCnt ==7){
            SE[2].Play();
        }
        if(enterCnt==8){
            Uni.color = new Color(1,1,1,1);
            SE[3].Play();
        }
        if(enterCnt==9){
            Uni.color = new Color(1,1,1,0);
        }
        if(enterCnt==20){
            Color tmp =CG.color;
            tmp.a += 0.005f;
            CG.color = tmp;
            SE[0].Pause();
        }
        if(enterCnt==21){
            //SceneChange
            SceneManager.LoadScene("StartMenuScene");
        }
    }
}
