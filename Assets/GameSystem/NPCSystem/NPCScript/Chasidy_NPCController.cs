using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasidy_NPCController : NPCController
{
    public Item HPMedicine;
    public override int GetTalkState()
    {
        int case_id = -1;

        if(NPCSO.ConversationCount==1)
        {
            case_id = 0;
            HPMedicine.isAcquired = true;
            HPMedicine.itemHeld += 1;
        }
        else if(NPCSO.ConversationCount==2)
        {
            case_id = 1;
            HPMedicine.isAcquired = true;
            HPMedicine.itemHeld += 1;
        }
        else if(NPCSO.ConversationCount > 2)
        {
            //重複上次對話
            case_id = 1;
        }

        return case_id;
    }
}
