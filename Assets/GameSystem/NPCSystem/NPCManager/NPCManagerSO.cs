using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Manager", menuName = "NPC Manager/NPC Manager", order = 0)]
public class NPCManagerSO : ScriptableObject {
    public List<NPCSO> NPCs = new List<NPCSO>();
}