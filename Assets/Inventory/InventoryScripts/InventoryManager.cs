using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInfomation;
    public GameObject emptySlot;
    public List<GameObject> slots = new List<GameObject>();
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable() //當InventoryManager被調用時執行
    {
        RefreshItem();
        instance.itemInfomation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfomation.text = itemDescription;
    }

    //public static void CreateNewItem(Item item)
    //{
    //    Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //    newItem.slotItem = item;
    //    newItem.slotImage.sprite = item.itemImage;
    //    newItem.slotNum.text = item.itemHeld.ToString();
    //}

    public static void RefreshItem() //背包已有此道具時，會更新數量而非放在新的一格
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++) //當背包已有此item，則先把slotGrid裡的child刪除
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++) //重新依照itemList的item去建立item
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot)); //把emptyslot放進List
            instance.slots[i].transform.SetParent(instance.slotGrid.transform); //將slots設置在slotGrid裡 
            instance.slots[i].GetComponent<Slot>().slotID = i; 
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }
}
