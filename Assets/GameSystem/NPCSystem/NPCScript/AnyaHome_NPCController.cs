using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyaHome_NPCController : NPCController
{
    public Item food;
    public override int GetTalkState()
    {
        int case_id = -1;

        if(NPCSO.ConversationCount==1)
        {
            case_id = 0;
        }
        else if(NPCSO.ConversationCount==2)
        {
            case_id = 1;
            food.isAcquired = true;
            food.itemHeld += 1;
        }
        else if(NPCSO.ConversationCount==3)
        {
            case_id = 2;
        }
        else if(NPCSO.ConversationCount>3)
        {
            //重複上次對話
            case_id = 2;
        }

        return case_id;
    }
}
