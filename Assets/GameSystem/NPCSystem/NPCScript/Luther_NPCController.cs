using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luther_NPCController : NPCController
{
    public ImportantItem importantItem;
    public Item flute;
    public override int GetTalkState()
    {
        int case_id = -1;

        if(NPCSO.ConversationCount==1)
        {
            case_id = 0;
            flute.isAcquired = true;
            flute.itemHeld += 1;
        }
        else if(NPCSO.ConversationCount==2)
        {
            case_id = 1;
            importantItem.GetImportantItem(5);
        }
        else if(NPCSO.ConversationCount > 2)
        {
            //重複上次對話
            case_id = 1;
        }

        return case_id;
    }
}
