using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/NPC")]
public class NPCSO : ScriptableObject
{
    public string NPCName;
    //與此NPC對話次數
    public int ConversationCount;
    //能觸發對話的條件
    public List<bool> ConversationCondition;
    public List<string> TxtName;
}
