using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New SpecialItem")]
public class SpecialItem : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public bool isAccquired;
    [TextArea]
    public string itemInfo;
}
