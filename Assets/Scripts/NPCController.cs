using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public PlayerController player;
    public GameObject Message;
    private TextAsset textAsset; //txt file, 預設是Assets/Resources資料夾
    private UsageCase useCase; //對話系統使用package
    public ExploreTime exploreTime;
    public MapManager mapManager;
    public NPCSO NPCSO;

    //根據對話次數對應txt檔案名稱
    public Dictionary<int, string> Conversation_txt = new Dictionary<int, string>();


    void Start()
    {
        useCase = GameObject.Find("MsgSystem").GetComponent<UsageCase>();
        foreach(var Item in NPCSO.TxtName.Select((value, index) => new { value, index }))
        {
            Debug.Log(Item.index);
            Debug.Log(Item.value);
            Conversation_txt.Add(Item.index, Item.value);
        }
    }

    private void Update()
    {
        if (!Message.activeSelf) //判斷對話框是否還active
        {
            player.isTalk = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Debug.Log(collision.gameObject.name);
        if (collision.tag == "Player")
        {
            bool noExplore = (exploreTime.exploreTimeSO.CurrentExploreTime == 0);
            if (player.startTalk && !noExplore) //玩家按下X啟動對話
            {
                player.startTalk = false;

                // Add conversation count and choose which conversation used
                NPCSO.ConversationCount += 1;
                // Reset previous conversation state to all false
                for (int i=0; i<NPCSO.ConversationCondition.Count; i++)
                {
                    NPCSO.ConversationCondition[i] = false;
                }
                // Set corresponding conversation to true
                int choice = GetTalkState();
                NPCSO.ConversationCondition[choice] = true;
                foreach (var cond in NPCSO.ConversationCondition.Select((value, index) => new { value, index })) {
                    if (cond.value == true)
                    {
                        choice = cond.index;
                    }
                }
                if(Conversation_txt[choice] != "None"){
                    //與 NPC 談話扣除探索一次並檢查是否用完探索次數
                    exploreTime.UseExploreTime(1);
                    mapManager.CheckExploreSetting();

                    textAsset = (TextAsset)Resources.Load(Conversation_txt[choice], typeof(TextAsset)); //Load .txt file from Assets/Resources
                    //Debug.Log(textAsset);
                    useCase.ReadTextDataFromAsset(textAsset); //設定對話框的對話內容並開始對話
                    Message.SetActive(true); //設定對話框active
                    player.ChangeAnimationState("Idle");
                    player.isTalk = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //讓玩家進入NPC附近之前按X，無法直接觸發對話框
    {
        player.startTalk = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.startTalk = false;
    }

    public virtual int GetTalkState(){
        Debug.Log("virtual return -1");
        return -1;
    }
}
