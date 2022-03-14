using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VillageTrigger : MonoBehaviour
{
    public PlayerController player;
    public GameObject Message;
    private TextAsset textAsset; //txt file, �w�]�OAssets/Resources��Ƨ�
    private UsageCase useCase; //��ܨt�Ψϥ�package
    private bool hasTalked = false;
    public NPCSO NPCSO;
    //�ھڹ�ܦ��ƹ���txt�ɮצW��
    public Dictionary<int, string> Conversation_txt = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        if (NPCSO.ConversationCount > 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            useCase = GameObject.Find("MsgSystem").GetComponent<UsageCase>();
            foreach (var Item in NPCSO.TxtName.Select((value, index) => new { value, index }))
            {
                // Debug.Log(Item.index);
                // Debug.Log(Item.value);
                Conversation_txt.Add(Item.index, Item.value);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Message.activeSelf) //�P�_��ܮجO�_��active
        {
            Debug.Log("Message not active");
            player.isTalk = false; //player�������
        }
        if (hasTalked && !Message.activeSelf)
        {
            Debug.Log("hastalked active false");
            this.gameObject.SetActive(false);
            //player.isTalk = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //�����a�i�JNPC���񤧫e��X�A�L�k����Ĳ�o��ܮ�
    {
        if (collision.tag == "Player" && !hasTalked)
        {
            //default is 0
            int choice = 0;
            foreach (var cond in NPCSO.ConversationCondition.Select((value, index) => new { value, index }))
            {
                if (cond.value == true)
                {
                    choice = cond.index;
                }
            }
            if (Conversation_txt[choice] != "None")
            {
                textAsset = (TextAsset)Resources.Load(Conversation_txt[choice], typeof(TextAsset)); //Load .txt file from Assets/Resources
                //Debug.Log(textAsset);
                useCase.ReadTextDataFromAsset(textAsset); //�]�w��ܮت���ܤ��e�ö}�l���
                Message.SetActive(true); //�]�w��ܮ�active
                player.isTalk = true; //player�}�l���
                player.ChangeAnimationState("Idle");
                hasTalked = true;
                NPCSO.ConversationCount += 1;
            }

        }
    }

}
