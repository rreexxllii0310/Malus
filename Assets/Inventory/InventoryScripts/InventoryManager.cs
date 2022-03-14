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

    private void OnEnable() //��InventoryManager�Q�եήɰ���
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

    public static void RefreshItem() //�I�]�w�����D��ɡA�|��s�ƶq�ӫD��b�s���@��
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++) //��I�]�w����item�A�h����slotGrid�̪�child�R��
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
            instance.slots.Clear();
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++) //���s�̷�itemList��item�h�إ�item
        {
            //CreateNewItem(instance.myBag.itemList[i]);
            instance.slots.Add(Instantiate(instance.emptySlot)); //��emptyslot��iList
            instance.slots[i].transform.SetParent(instance.slotGrid.transform); //�Nslots�]�m�bslotGrid�� 
            instance.slots[i].GetComponent<Slot>().slotID = i; 
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
        }
    }
}
