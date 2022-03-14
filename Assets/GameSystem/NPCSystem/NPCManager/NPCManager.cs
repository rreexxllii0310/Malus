using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCManager : MonoBehaviour
{
    public NPCManagerSO nPCManagerSO;

    public void ResetToInitial()
    {
        foreach (NPCSO npcSO in nPCManagerSO.NPCs)
        {
            npcSO.ConversationCount = 0;
            for (int i = 0; i < npcSO.ConversationCondition.Count; i++)
            {
                if (i == 0)
                {
                    npcSO.ConversationCondition[i] = true;
                }
                else npcSO.ConversationCondition[i] = false;

            }
        }
    }
}
