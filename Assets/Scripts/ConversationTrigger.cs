using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    public PlayerController player;
    public GameObject Message;
    private TextAsset textAsset; //txt file, 預設是Assets/Resources資料夾
    private UsageCase useCase; //對話系統使用package
    private bool hasTalked = false;
    public NPCSO NPCSO;
    //根據對話次數對應txt檔案名稱
    public Dictionary<int, string> Conversation_txt = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        useCase = GameObject.Find("MsgSystem").GetComponent<UsageCase>();
        foreach(var Item in NPCSO.TxtName.Select((value, index) => new { value, index }))
        {
            // Debug.Log(Item.index);
            // Debug.Log(Item.value);
            Conversation_txt.Add(Item.index, Item.value);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Message.activeSelf) //判斷對話框是否還active
        {
            Debug.Log("Message not active");
            player.isTalk = false; //player結束對話
        }
        if(hasTalked && !Message.activeSelf)
        {
            Debug.Log("hastalked active false");
            this.gameObject.SetActive(false);
            //player.isTalk = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //讓玩家進入NPC附近之前按X，無法直接觸發對話框
    {
        if (collision.tag == "Player" && !hasTalked)
        {
            //default is 0
            int choice = 0;
            foreach (var cond in NPCSO.ConversationCondition.Select((value, index) => new { value, index })) {
                if (cond.value == true)
                {
                    choice = cond.index;
                }
            }
            if(Conversation_txt[choice] != "None"){
                textAsset = (TextAsset)Resources.Load(Conversation_txt[choice], typeof(TextAsset)); //Load .txt file from Assets/Resources
                //Debug.Log(textAsset);
                useCase.ReadTextDataFromAsset(textAsset); //設定對話框的對話內容並開始對話
                Message.SetActive(true); //設定對話框active
                player.isTalk = true; //player開始對話
                player.ChangeAnimationState("Idle");
                hasTalked = GetCoversationState();
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }
    public virtual bool GetCoversationState(){
        Debug.Log("virtual return True");
        return true;
    }
}
