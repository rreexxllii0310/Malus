using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hartley_NPCController : NPCController
{
    public MapRegionSO mapRegionSO;
    public override int GetTalkState()
    {
        int case_id = -1;

        if (NPCSO.ConversationCount == 1)
        {
            case_id = 0;
        }
        else
        {
            case_id = 1;
        }

        return case_id;
    }
}
