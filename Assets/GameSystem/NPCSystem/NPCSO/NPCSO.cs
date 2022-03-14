using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC/NPC")]
public class NPCSO : ScriptableObject
{
    public string NPCName;
    //�P��NPC��ܦ���
    public int ConversationCount;
    //��Ĳ�o��ܪ�����
    public List<bool> ConversationCondition;
    public List<string> TxtName;
}
