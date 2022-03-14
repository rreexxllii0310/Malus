using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Inventory myBag;
    public Transform originalParent;
    private int currentItemID;
    public void OnBeginDrag(PointerEventData eventData) //�}�l�ƹ��즲item
    {
        originalParent = transform.parent; //�����쥻item��parent(slot)
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        transform.SetParent(transform.parent.parent); //�Nitem��parent�Ȯɲ���W�W�h
        transform.position = eventData.position; //��item���H���в���
        GetComponent<CanvasGroup>().blocksRaycasts = false; //���g�u���|�Qitem�צ�
    }

    public void OnDrag(PointerEventData eventData) //���b�ƹ��즲item
    {
        transform.position = eventData.position; //��item���H���в���
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name); //���o�g�u�g�쪺object name
    }

    public void OnEndDrag(PointerEventData eventData) //�����ƹ��즲item
    {
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject == null); //���o�g�u�g�쪺object name
        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "itemImage") //��e��l����L���~
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent); //�N�즲��item��Parent�]���s��Slot
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position; //�N�즲��item��m�]���s��Slot����m
                //�洫itemList �x�s���~ID
                var temp = myBag.itemList[currentItemID];
                myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position; //���slot��item��m����즲��item��slot����m
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent); //���slot��parent�]���즲��item��parent
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }
            else if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
            {
                //�즲����l�S�����~
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
                //�]�mitemList �x�s���~ID
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID] = myBag.itemList[currentItemID];
                //�ѨM�ۤv��^��쪫�~����
                if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                    myBag.itemList[currentItemID] = null;

                eventData.pointerCurrentRaycast.gameObject.transform.GetChild(0).SetParent(originalParent); //���e��l��item����originparent
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
