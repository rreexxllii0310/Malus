using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanya_NPCController : NPCController
{
    public Item orbit;
    public override int GetTalkState()
    {
        int case_id = -1;

        if(NPCSO.ConversationCount==1)
        {
            case_id = 0;
            orbit.isAcquired = true;
            orbit.itemHeld += 1;
        }
        else if(NPCSO.ConversationCount==2)
        {
            case_id = 1;
        }
        else if(NPCSO.ConversationCount > 2)
        {
            //重複上次對話
            case_id = 1;
        }

        return case_id;
    }
}
