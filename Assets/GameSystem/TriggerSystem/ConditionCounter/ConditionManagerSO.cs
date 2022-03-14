using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Condition Manager", menuName = "Condition Manager/ConditionManager", order = 0)]
public class ConditionManagerSO : ScriptableObject
{
    public List<ConditionCounterSO> NPCs = new List<ConditionCounterSO>();
}