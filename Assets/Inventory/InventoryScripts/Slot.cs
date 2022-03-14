using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour //�I�]����l
{
    public int slotID;
    public Item slotItem; //��l��item
    public Image slotImage; //item��image
    public Text slotNum; //item���ƶq
    public string slotInfo;

    public GameObject itemInSlot;
    public void ItemOnClicked() //�ƹ��I��item
    {
        InventoryManager.UpdateItemInfo(slotInfo); //���item�ԭz
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
