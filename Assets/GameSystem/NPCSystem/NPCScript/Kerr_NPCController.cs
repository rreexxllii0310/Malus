using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kerr_NPCController : NPCController
{
    public List<Item> condition_items = new List<Item>();
    public Item charm_item;
    public override int GetTalkState(){
        int case_id = -1; 
        
        //Case 1: 前提：第一次拜訪Kerr
        if(NPCSO.ConversationCount<=1)
        {
            //D_Kerr_1
            case_id = 0;
        }
        else
        {
            //Case 2: 已經先找過Kerr一次，然後與村民交流未滿三次（收到禮物少於三樣)
            if(!MatchCharmCondition()){
                //D_Kerr_2
                case_id = 1;
            }
            else
            {
                //Case 3: 已經先找過Kerr一次，然後與村民交流至少滿三次（收到三樣禮物)
                if(!charm_item.isAcquired)
                {
                    //D_Kerr_3
                    case_id = 2;
                    charm_item.isAcquired = true;
                    charm_item.itemHeld += 1;
                }
                //Case 4: 已經從Kerr那邊收到護身符，之後不論再回來找Kerr多少次，都會是一樣的劇情
                else
                {
                    //D_Kerr_4
                    case_id = 3;
                }
            }
            
        }
        Debug.Log("Kerr return case id "+case_id.ToString());
        return case_id;
    }

    private bool MatchCharmCondition()
    {
        //判斷是否與村民交流滿三次
        int count = 0;
        foreach (Item item in condition_items){
            if(item.isAcquired){
                count +=1;
            }
        }
        return count>=3 ? true : false;
    }
}
