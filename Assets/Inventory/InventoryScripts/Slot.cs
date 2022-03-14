using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour //背包的格子
{
    public int slotID;
    public Item slotItem; //格子的item
    public Image slotImage; //item的image
    public Text slotNum; //item的數量
    public string slotInfo;

    public GameObject itemInSlot;
    public void ItemOnClicked() //滑鼠點擊item
    {
        InventoryManager.UpdateItemInfo(slotInfo); //顯示item敘述
    }

    public void SetupSlot(Item item)
    {
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }
        slotImage.sprite = item.itemImage;
        slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
    }
}
