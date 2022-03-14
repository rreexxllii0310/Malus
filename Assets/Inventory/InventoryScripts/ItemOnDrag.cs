using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Inventory myBag;
    public Transform originalParent;
    private int currentItemID;
    public void OnBeginDrag(PointerEventData eventData) //開始滑鼠拖曳item
    {
        originalParent = transform.parent; //紀錄原本item的parent(slot)
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent); //將item的parent暫時移到上上層
        transform.position = eventData.position; //讓item跟隨鼠標移動
        GetComponent<CanvasGroup>().blocksRaycasts = false; //讓射線不會被item擋住
    }

    public void OnDrag(PointerEventData eventData) //正在滑鼠拖曳item
    {
        transform.position = eventData.position; //讓item跟隨鼠標移動
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name); //取得射線射到的object name
    }

    public void OnEndDrag(PointerEventData eventData) //結束滑鼠拖曳item
    {
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject == null); //取得射線射到的object name
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "itemImage") //當前格子有其他物品
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent); //將拖曳的item的Parent設為新的Slot
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position; //將拖曳的item位置設為新的Slot的位置
                //交換itemList 儲存物品ID
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position; //把原slot的item位置移到拖曳的item的slot的位置
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent); //把原slot的parent設為拖曳的item的parent
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
            {
                //拖曳的格子沒有物品
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //設置itemList 儲存物品ID
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID] = myBag.itemList[currentItemID];
                //解決自己放回原位物品消失
                if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                    myBag.itemList[currentItemID] = null;

                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).SetParent(originalParent); //把當前格子的item移到originparent
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

        }
        //Debug.Log(originalPos);
        transform.position = originalParent.position;
        transform.SetParent(originalParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
