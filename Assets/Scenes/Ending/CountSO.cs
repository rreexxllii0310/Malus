using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Count", menuName = "Count/Count")]
public class CountSO : ScriptableObject
{
    public int RepairCount;
    public int ObserveCount;
}
