using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item Manager", menuName = "Item Manager/Item Manager", order = 0)]
public class ItemManagerSO : ScriptableObject {
    public List<Item> items = new List<Item>();
}
